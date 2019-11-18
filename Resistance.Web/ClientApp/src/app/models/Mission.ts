import { MissionState } from "./MissionState";

export class Mission {
    state: MissionState;
    failsRequired: number;
    missionNo: number;
    numberOfPlayers: number;
}