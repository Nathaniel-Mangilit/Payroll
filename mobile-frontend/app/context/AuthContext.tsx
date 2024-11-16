import { createContext, useContext, useEffect, useState } from "react";
import axios from "axios";
import * as SecureStore from "expo-secure-store";
import { handleError } from "../helpers/ErrorHandler";

interface AuthProps {
  authState?: {
    userId: string | null;
    token: string | null;
    authenticated: boolean | null;
  };
  onRegister?: (
    email: string,
    userName: string,
    password: string
  ) => Promise<any>;
  onLogin?: (userName: string, password: string) => Promise<any>;
  getUser?: (userId: string) => Promise<any>;
  onLogout?: () => Promise<any>;
}

const TOKEN_KEY = "My-Token";
const USER_KEY = "My-User";

export const API_URL = "https://8zvsjchz-5067.asse.devtunnels.ms/api";
const AuthContext = createContext<AuthProps>({});

export const useAuth = () => {
  return useContext(AuthContext);
};

export const AuthProvider = ({ children }: any) => {
  const [authState, setAuthState] = useState<{
    userId: string | null;
    token: string | null;
    authenticated: boolean | null;
  }>({
    userId: null,
    token: null,
    authenticated: null,
  });

  useEffect(() => {
    const loadToken = async () => {
      // load token from secure store
      const token = await SecureStore.getItemAsync(TOKEN_KEY);
      console.log("Token Stored Successfully :", token);

      // load user ID from secure store
      const userId = await SecureStore.getItemAsync(USER_KEY);
      console.log("User ID Stored Successfully :", userId);

      if (token) {
        axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
        setAuthState({
          userId: userId,
          token: token,
          authenticated: true,
        });
      }
    };
    loadToken();
  }, []);

  const register = async (
    email: string,
    userName: string,
    password: string
  ) => {
    try {
      return await axios.post(
        `${API_URL}/account/register`,
        {
          email,
          userName,
          password,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
    } catch (error) {
      handleError(error);
    }
  };

  const login = async (userName: string, password: string) => {
    try {
      const result = await axios.post(
        `${API_URL}/account/login`,
        {
          userName,
          password,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      setAuthState({
        userId: result.data.userId,
        token: result.data.token,
        authenticated: true,
      });
      axios.defaults.headers.common[
        "Authorization"
      ] = `Bearer ${result.data.token}`;

      await SecureStore.setItemAsync(USER_KEY, result.data.userId);
      await SecureStore.setItemAsync(TOKEN_KEY, result.data.token);

      return result;
    } catch (error) {
      handleError(error);
    }
  };

  const logout = async () => {
    //delete token
    await SecureStore.deleteItemAsync(TOKEN_KEY);
    await SecureStore.deleteItemAsync(USER_KEY);

    //update headers
    axios.defaults.headers.common["Authorization"] = "";
    //delete auth state
    setAuthState({
      userId: null,
      token: null,
      authenticated: null,
    });
    alert("Logout Successful");
    console.log(TOKEN_KEY);
  };

  const value = {
    onRegister: register,
    onLogin: login,
    onLogout: logout,
    authState,
  };
  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
