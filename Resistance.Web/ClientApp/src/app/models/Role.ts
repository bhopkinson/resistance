export enum Role {
    Regular,
    Chief,
    Hunter,
    Dummy
}

export class RoleUtil {
    public static toString(role: Role) {
        return Role[role];
    }
}