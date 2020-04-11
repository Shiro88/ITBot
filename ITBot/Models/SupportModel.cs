using System;
using System.Collections.Generic;
using System.Text;

namespace ITBot.Models
{
    public class SupportModel
    {

        public  Results results { get; set; }

    
     

            public int count { get; set; }
            public string next_page { get; set; }

            public string page { get; set; }
            public int page_count { get; set; }
            public int per_page { get; set; }

            public int previous_page { get; set; }
        

        public class Results
        {
            public int id { get; set; }
            public string url { get; set; }

            public string html_url { get; set; }
            public int author_id { get; set; }
            public Boolean comments_disabled { get; set; }
            public Boolean draft { get; set; }
            public Boolean promoted { get; set; }
            public int position { get; set; }
            public int vote_sum { get; set; }

            public int vote_count { get; set; }

            public int section_id { get; set; }

            public string created_at { get; set; }


            public string updated_at { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public string source_locale { get; set; }
            public string locale { get; set; }

            public Boolean outdated { get; set; }
            public string[] outdated_locales { get; set; }
            public string edited_at { get; set; }
            public string user_segment_id { get; set; }
            public int permission_group_id { get; set; }

            public string[] label_names {get; set;}

            public string body { get; set; }
            public string snippet { get; set; }
            public string result_type { get; set; }
        }
}
}
