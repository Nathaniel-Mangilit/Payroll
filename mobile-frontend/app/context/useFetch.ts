import React, { useEffect, useState } from "react";
import axios from "axios";
import { User } from "../components/intefaces";
import { API_URL, useAuth } from "./AuthContext";

export interface user {
  user: User;
}

function useFetch() {
  const { authState } = useAuth();
  const [data, setData] = useState<User | null>(null);
  const [loading, isLoading] = useState(false);
  const [error, setError] = useState(false);

  useEffect(() => {
    isLoading(true);
    axios
      .get(`${API_URL}/userprofiles?AppUserId=${authState?.userId}`)
      .then((response) => {
        console.log("user", response.data[0].firstName);
        setData(response.data);
      })
      .catch((err) => {
        setError(err);
      })
      .finally(() => {
        isLoading(false);
      });
  }, []);
  return { data, loading, error };
}
export default useFetch;
