using System.Net;
using System.Text;
using MoodleAPI.Model;
using MoodleAPI.Model.DTO;
using Newtonsoft.Json;
namespace MoodleAPI
{
    public class MoodleDownloader
    {
        private string _baseUrl;
        private string _token;

        private string _coreWebFunctionGetCourseContents = "core_course_get_contents"; //NOW
        //get course content (modules + web service file urls)

        private string _coreWebFunctionGetUsersByField = "core_user_get_users_by_field";

        private string _modWebFunctionGetForumDiscussions = "mod_forum_get_forum_discussions";
        //Get a particular discussion post

        private string _modWebFunctionGetDiscussionPosts = "mod_forum_get_discussion_posts";
        //Returns a list of forum posts for a discussion.

        private string _modWebFunctionGetForumsByCourses = "mod_forum_get_forums_by_courses";
        //Returns a list of forum instances in a provided set of courses, if no courses are provided then all the forum instances the user has access to will be returned.

        private string _coreWebFunctionGetCoursesByUser = "core_enrol_get_users_courses";
        //Returns the contents of a page.

        private string _username = "bojanramic";
        private string _password = "password";
        private string _service = "moodle_mobile_app";

        private string _parameterSeparator = "&";

        private int NumberOfCourses;

        public List<CourseDTO> Courses;
        public List<FileDTO> Files;
        public List<ForumDTO> Forums;
        public List<UrlDTO> Urls;

        public MoodleDownloader()
        {
            _baseUrl = "https://el.etfbl.net/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json";
            _token = GetToken();
            Courses = new List<CourseDTO>();
            Files = new List<FileDTO>();
            Forums = new List<ForumDTO>();
            Urls = new List<UrlDTO>();
            NumberOfCourses = GetEnrolledCoursesAndNum();
        }
        public MoodleDownloader(string baseUrl)
        {
            _baseUrl = baseUrl;
            _token = GetToken();
        }

        private int GetEnrolledCoursesAndNum()
        {
            string url = _baseUrl;
            url = String.Format(url, _token, _coreWebFunctionGetUsersByField);
            url = url + _parameterSeparator + "field={0}" + _parameterSeparator + "values[]={1}";
            url = String.Format(url, "username", _username);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //get the response
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            var user = JsonConvert.DeserializeObject<List<User>>(contents).FirstOrDefault();

            url = _baseUrl;
            url = String.Format(url, _token, _coreWebFunctionGetCoursesByUser);
            url = url + _parameterSeparator + "userid={0}";
            url = String.Format(url, user.Id);
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            response = (HttpWebResponse)request.GetResponse();
            resStream = response.GetResponseStream();
            reader = new StreamReader(resStream);
            contents = reader.ReadToEnd();

            var courses = JsonConvert.DeserializeObject<List<CourseByUser>>(contents);

            foreach (var item in courses)
            {
                var course = new CourseDTO()
                {
                    Id = item.Id,
                    Name = item.FullName,
                    Files = new List<FileDTO>(),
                    Forums = new List<ForumDTO>(),
                    Urls = new List<UrlDTO>()
                };
                Courses.Add(course);
            }
            return courses.Count;
        }

        public void Scrape()
        {
            //TODO: check if the token is valid

            List<int> courseIds = new();
            foreach (CourseDTO course in Courses)
            {
                courseIds.Add(course.Id);
                //GetCourseFileContents(course.Id);
            }

            GetForums(courseIds);

        }

        private string GetToken()
        {
            string url = String.Format("https://el.etfbl.net/login/token.php?username={0}&password={1}&service={2}", _username, _password, _service);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //get the response
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TokenJson>(contents).Token;
        }

        //the endpoint accepts an array of ids for all the forums
        public void GetForumsContents(List<int> courseIds)
        {
            string url = _baseUrl + _parameterSeparator;
            for (int i = 0; i < courseIds.Count; i++)
            {
                url += "courseids[]=" + courseIds[i];
                if (i == courseIds.Count - 1)
                    break;
                url += _parameterSeparator;
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();
            var forums = JsonConvert.DeserializeObject<Forum>(contents);

        } 

        public void GetForums(List<int> courseIds)
        {
            string url = _baseUrl;
            url = String.Format(url, _token, _modWebFunctionGetForumsByCourses);

            //attack all the ids
            url += _parameterSeparator;
            foreach(int courseId in courseIds)
            {
                url = url + "courseids[]=" + courseId + _parameterSeparator;
            }
            url = url.TrimEnd('&');

            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;

            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            var forums = JsonConvert.DeserializeObject<List<Forum>>(contents);

            foreach(var forum in forums)
            {
                ForumDTO forumDTO = new()
                {
                    Id = forum.Id,
                    CourseId = forum.Course,
                    Name = forum.Name,
                    Type = forum.Type,
                    Discussions = GetDiscussions(forum.Id)
                };
                Forums.Add(forumDTO);
                Courses.First(c => c.Id == forumDTO.CourseId).Forums.Add(forumDTO);
                Console.WriteLine(forumDTO.Name);
            }
        }

        private List<DiscussionDTO> GetDiscussions(int id)
        {
            //make the request for discussions contents
            string url = _baseUrl;
            url = String.Format(url, _token, _modWebFunctionGetForumDiscussions);
            url = url + _parameterSeparator + "forumid={0}";
            url = String.Format(url, id);

            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            var discussions = JsonConvert.DeserializeObject<DiscussionsWrapperObject>(contents);

            var list = new List<DiscussionDTO>();

            foreach(var discussion in discussions.Discussions)
            {
                DiscussionDTO discussionDTO = new() 
                {
                    Id = discussion.Id, //there are two, the other one goes if I want the posts, which one?
                    Name = discussion.Name,
                    Author = discussion.UserFullName,
                    Created = DateTime.FromFileTime(discussion.TimeStart), //TODO: Check
                    Posts = GetPostsFromDiscussion(discussion.DiscussionId),
                };
                list.Add(discussionDTO);
            }
            return list;
        }

        private List<PostDTO> GetPostsFromDiscussion(int discussionId)
        {
            string url = _baseUrl;
            url = String.Format(url, _token, _modWebFunctionGetDiscussionPosts);
            url = url + _parameterSeparator + "discussionid={0}";
            url = String.Format(url, discussionId);

            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            var wrapper = JsonConvert.DeserializeObject<PostsWrapperObject>(contents);
            
            var list = new List<PostDTO>();

            foreach(var post in wrapper.Posts)
            {
                PostDTO postDTO = new PostDTO()
                {
                    Id = post.Id,
                    Title = post.Subject,
                    Author = post.Author.FullName,
                    ReplyTitle = post.ReplySubject
                };

                list.Add(postDTO);
            }

            return list;
        }

        public void GetCourseFileContents(int id)
        {
            string url = _baseUrl + _parameterSeparator + "courseid={2}";
            url = String.Format(url, _token, _coreWebFunctionGetCourseContents, id);

            var request = WebRequest.Create(url) as HttpWebRequest;

            var response = request.GetResponse() as HttpWebResponse;

            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            var sections = JsonConvert.DeserializeObject<List<CourseSection>>(contents);

            //now I need files, folders, pages, posts

            //get all the modules, files are in them

            foreach (var section in sections)
            {
                foreach (var module in section.Modules)
                {
                    if (module.ModName.Contains("forum") || module.ModName.Contains("label"))
                        continue;

                    if (module.ModName.Contains("choice") || module.ModName.Contains("assign") || module.ModName.Contains("url"))
                    {
                        UrlDTO urlDTO = CreateUrlDTO(module.Id, id, module.Name, module.ModName, module.Url);
                        Console.WriteLine(urlDTO.Name);
                        Urls.Add(urlDTO);
                        Courses.First(c => c.Id == urlDTO.CourseId).Urls.Add(urlDTO);
                        continue;
                    }

                    foreach (var content in module.Contents)
                    {
                        FileDTO fileDTO; //TODO: can be done better
                        if (content.MimeType is null && content.FileName.Contains("html"))
                        {
                            fileDTO = CreateFileDTO(section.Id, id, module.Id, module.Url, module.Name, content.MimeType, content.FileUrl);
                            break;
                        }//if it's a video
                        if (content.MimeType.Contains("video"))
                        {
                            var urlDTO = CreateUrlDTO(module.Id, id, module.Name, content.MimeType, module.Url);
                            Urls.Add(urlDTO);
                            Console.WriteLine(urlDTO.Name);
                            Courses.First(c => c.Id == urlDTO.CourseId).Urls.Add(urlDTO);
                            break;
                        }

                        //if it is not a url, then it is a file
                        fileDTO = CreateFileDTO(section.Id, id, module.Id, module.Url, module.Name, content.MimeType, content.FileUrl);
                        Files.Add(fileDTO);
                        //add to the course all belonging files
                        Courses.First(c => c.Id == fileDTO.CourseId)?.Files.Add(fileDTO);
                    }
                }
            }
        }

        private FileDTO CreateFileDTO(int courseSectionId, int courseId, int courseModuleId, string url, string name, string type, string fileUrl)
        {
            FileDTO fileDTO = new();
            try
            {
                fileDTO.CourseSectionId = courseSectionId;
                fileDTO.CourseId = courseId;
                fileDTO.CourseModuleId = courseModuleId;
                fileDTO.Url = url;
                fileDTO.Name = name;
                fileDTO.Type = type;
                fileDTO.Data = DownloadFileContent(fileUrl);
                Console.WriteLine(name);
                //when MimeType is null, then it is a page, html page
            }
            catch (WebException exception)
            {
                //TODO: logging
            }
            return fileDTO;
        }

        private UrlDTO CreateUrlDTO(int id, int courseId, string name, string type, string url)
        {
            return new()
            {
                Id = id,
                CourseId = courseId,
                Name = name,
                Type = type,
                Url = url
            };
        }

        private int[] DownloadFileContent(string url)
        {
            url = url + _parameterSeparator + "token={0}";
            url = String.Format(url, _token);

            var request = WebRequest.Create(url) as HttpWebRequest;

            var response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            List<int> bytes = new();    //TODO: byte or int?
            int temp;
            while((temp = reader.Read()) != -1)
            {
                bytes.Add(temp);
            }
            return bytes.ToArray();
        }

        //public List<FileDTO> DownloadFolderContents(List<string> urls)
        //{
        //    var list = new List<FileDTO>();
        //    foreach (string url in urls)
        //    {
        //        string tokenizedUrl = url + _parameterSeparator + "token={0}";
        //        string finalUrl = String.Format(tokenizedUrl, _token);
        //        HttpWebRequest request = WebRequest.Create(finalUrl) as HttpWebRequest;
        //        request.Method = "GET";
        //
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        Stream resStream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(resStream);
        //        [] file = Encoding.ASCII.GetBytes(reader.ReadLine());
        //        FileDTO dto = new FileDTO()
        //        {
        //            Data = file
        //        };
        //        list.Add(dto);
        //    }
        //    return list;
        //}



        public static void Main(string[] args)
        {
            MoodleDownloader downloader = new MoodleDownloader();
            downloader.Scrape();
        }
    }
}
