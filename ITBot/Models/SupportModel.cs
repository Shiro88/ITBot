namespace ITBot.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SupportModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next_page")]
        public object NextPage { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("page_count")]
        public long PageCount { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("previous_page")]
        public object PreviousPage { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("author_id")]
        public long AuthorId { get; set; }

        [JsonProperty("comments_disabled")]
        public bool CommentsDisabled { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("promoted")]
        public bool Promoted { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("vote_sum")]
        public long VoteSum { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("section_id")]
        public long SectionId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("source_locale")]
        public string SourceLocale { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("outdated")]
        public bool Outdated { get; set; }

        [JsonProperty("outdated_locales")]
        public object[] OutdatedLocales { get; set; }

        [JsonProperty("edited_at")]
        public DateTimeOffset EditedAt { get; set; }

        [JsonProperty("user_segment_id")]
        public object UserSegmentId { get; set; }

        [JsonProperty("permission_group_id")]
        public long PermissionGroupId { get; set; }

        [JsonProperty("label_names")]
        public string[] LabelNames { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("result_type")]
        public string ResultType { get; set; }
    }
}
