import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";
import axios from "axios";
const api = "http://localhost:5067/api/";

export const loginApi = async (username: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(api + `account/login`, {
      username: username,
      password: password,
    });
    console.log("Login result:", data);
    return data;
  } catch (error) {
    handleError(error);
  }
};
export const registerApi = async (
  email: string,
  username: string,
  password: string
) => {
  try {
    const data = await axios.post<UserProfileToken>(api + `account/register`, {
      email: email,
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
