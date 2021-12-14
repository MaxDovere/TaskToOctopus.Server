using System.ComponentModel.DataAnnotations;

namespace TaskOnOctopus.DomainApi
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
