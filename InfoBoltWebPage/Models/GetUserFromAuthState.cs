namespace InfoBoltWebPage.Models
{
    public class GetUserFromAuthState
    {
        public static async Task<string> GetEmailFromAuthUser(Task<AuthenticationState> state)
        {
            var authState = await state;
            var user = authState.User;
            if (user is not null && user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirst(claims => claims.Type == ClaimTypes.Name);
                return claim.Value;
            }
            return "";
        }
        public static async Task<int> GetIdFromAuthUser(Task<AuthenticationState> state)
        {
            var authState = await state;
            var user = authState.User;
            if (user is not null && user.Identity.IsAuthenticated)
            {
                var claim = user.FindFirst(claims => claims.Type == ClaimTypes.NameIdentifier);
                return int.Parse(claim.Value);
            }
            return -1;
        }
    }
}
