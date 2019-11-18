export enum Team {
    Resistance,
    Spy
}

export class TeamUtil {
    public static toString(team: Team) {
        return Team[team];
    }
}