import * as Yup from "yup";
import { useAuth } from "../../../Context/useAuth";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

type LoginFormInputs = {
  userName: string;
  password: string;
};

const validation = Yup.object().shape({
  userName: Yup.string().required("Username is Required!"),
  password: Yup.string().required("Password is Required!"),
});

const LoginPage = () => {
  const { loginUser } = useAuth();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginFormInputs>({ resolver: yupResolver(validation) });

  const handleLogin = (form: LoginFormInputs) => {
    loginUser(form.userName, form.password);
  };

  return (
    <Card className="w-full max-w-sm">
      <CardHeader>
        <CardTitle className="text-2xl">Login</CardTitle>
        <CardDescription>
          Enter your email below to login to your account.
        </CardDescription>
      </CardHeader>
      <CardContent className="grid gap-4">
        <div className="grid gap-2">
          <Label htmlFor="username">Username</Label>
          <Input
            id="username"
            type="text"
            placeholder="Username"
            {...register("userName")}
            required
          />
          {errors.userName ? <p>{errors.userName.message}</p> : ""}
        </div>
        <div className="grid gap-2">
          <Label htmlFor="password">Password</Label>
          <Input
            id="password"
            type="password"
            {...register("password")}
            required
          />
          {errors.password ? <p>{errors.password.message}</p> : ""}
        </div>
      </CardContent>
      <CardFooter>
        <Button className="w-full" onClick={handleSubmit(handleLogin)}>
          Sign in
        </Button>
      </CardFooter>
    </Card>
  );
};

export default LoginPage;
