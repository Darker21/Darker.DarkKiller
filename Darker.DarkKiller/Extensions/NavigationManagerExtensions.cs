using Darker.DarkKiller.Constants;
using Microsoft.AspNetCore.Components;

namespace Darker.DarkKiller.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static void NavigateToHome(this NavigationManager navMan)
        {
            navMan.NavigateTo(AppRoutes.Home);
        }

        public static void NavigateToGame(this NavigationManager navMan)
        {
            navMan.NavigateTo(AppRoutes.Game);
        }
    }
}
