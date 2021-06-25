namespace Shop.Application.Utils
{
    public class JwtDto
    {
        public string Token { get; set; }

        public JwtDto(string token)
        {
            Token = token;
        }
    }
}