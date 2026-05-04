using System.ComponentModel.DataAnnotations;
using Lucene.Net.Queries.Function.DocValues;

namespace population.Headless.Revalidate
{
    public class NextJsRevalidateOptions
    {
        [Required]
        public bool Enabled { get; set; }
        
        public string? WebHookUrls { get; set; } = null;

        public string WebHookSecret { get; set; } = string.Empty;

    }
}