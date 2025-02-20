import { NavLink } from "react-router-dom";
import Cookies from "js-cookie";

const Navbar = () => {
  const authData = JSON.parse(Cookies.get("authData"));
  const userType = authData.userType;
  return (
    <nav className="bg-white p-2 flex items-center justify-between w-full shadow-md px-9 fixed top-0 left-0 z-0">
      <div className="flex items-center">
        <img
          onClick={() => (window.location.href = "/")}
          src="/logo.svg"
          alt="Site Logo"
          className="w-20 h-20 rounded-full mr-4"
        />
      </div>
      <div className="flex space-x-4">
        <NavLink
          to="/"
          className={({ isActive }) =>
            isActive
              ? "font-bold text-[#2C2C2C]"
              : "text-[#6C757D] hover:text-[#2C2C2C]"
          }
        >
          Home
        </NavLink>
        <NavLink
          to="/profile"
          className={({ isActive }) =>
            isActive
              ? "font-bold text-[#2C2C2C]"
              : "text-[#6C757D] hover:text-[#2C2C2C]"
          }
        >
          Profile
        </NavLink>
        {userType.toLowerCase() === "student" ? (
          <NavLink
            to="/notification"
            className={({ isActive }) =>
              isActive
                ? "font-bold text-[#2C2C2C]"
                : "text-[#6C757D] hover:text-[#2C2C2C]"
            }
          >
            Notification
          </NavLink>
        ) : (
          <NavLink
            to="/applications"
            className={({ isActive }) =>
              isActive
                ? "font-bold text-[#2C2C2C]"
                : "text-[#6C757D] hover:text-[#2C2C2C]"
            }
          >
            Applications
          </NavLink>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
