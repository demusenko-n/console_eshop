namespace useless
{
    public class MenuManager
    {
        private readonly GuestMenu _guestMenu;

        private readonly RegisteredUserMenu _registeredUserMenu;

        private readonly AdminMenu _adminMenu;

        public MenuManager(GuestMenu guestMenu, RegisteredUserMenu registeredUserMenu, AdminMenu adminMenu)
        {
            _guestMenu = guestMenu;
            _registeredUserMenu = registeredUserMenu;
            _adminMenu = adminMenu;
        }

        public void Start()
        {
            MenuContext menuContext = new MenuContext(_guestMenu);

            while (true)
            {
                switch (SessionManager.CurrentUser.Role)
                {
                    case Role.Guest:
                        menuContext = new MenuContext(_guestMenu);
                        break;
                    case Role.RegisteredUser:
                        menuContext = new MenuContext(_registeredUserMenu);
                        break;
                    case Role.Administrator:
                        menuContext = new MenuContext(_adminMenu);
                        break;
                }
                menuContext.Build();
            }
        }
    }
}