
namespace E_Commerce.API.Factories
{
    internal class ValidationError
    {
        public string Field { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}