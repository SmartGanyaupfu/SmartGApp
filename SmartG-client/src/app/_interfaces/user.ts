import { Role } from "./role";

export interface User {
    firstName: string;
    lastName: string;
    id: string;
    userName: string;
    email: string;
    phoneNumber: string;
   
    imageUrl?:string;
    roles: Role[];
}
