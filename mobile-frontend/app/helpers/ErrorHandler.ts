import axios from "axios";

export const handleError = (error: any) => {
  if (axios.isAxiosError(error)) {
    const err = error.response;
    if (Array.isArray(err?.data.errors)) {
      for (let val of err?.data.errors) {
        alert(val.description);
      }
    } else if (typeof err?.data === "object") {
      for (let e in err?.data.errors) {
        alert(err?.data.errors[e][0]);
      }
    } else if (err?.data) {
      alert(err?.data);
    } else if (err?.status === 401) {
      console.log(err);
      alert("Login Failed.\nIncorrect Username or Password");
    } else if (err) {
      alert(err?.data);
    }
  }
};
