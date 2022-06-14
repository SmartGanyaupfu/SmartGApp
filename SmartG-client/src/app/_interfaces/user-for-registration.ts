import { Role } from "./role";

export interface UserForRegistration {
    lastName: string;
    userName: string;
    password: string;
    confirmPassword: string;
    email: string;
    phoneNumber: string;
    roles: Role[];
    clientURI: string;
   
}
