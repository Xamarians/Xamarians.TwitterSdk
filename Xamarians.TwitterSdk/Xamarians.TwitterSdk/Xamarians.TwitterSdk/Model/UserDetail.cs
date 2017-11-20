namespace Xamarians.TwitterSdk.Model
{
    public class UserDetail
    {
        public string TwitterId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public string Text { get; set; }
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
    }
}