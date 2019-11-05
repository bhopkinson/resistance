using Resistance.GameModel;
using System;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public class MissionInitialisation : IMissionInitialisation
    {
        public IEnumerable<Mission> InitiliseMissions(int numberOfPlayers)
        {
            var missions = new List<Mission>();
            var missionNumber = 1;

            while (missionNumber < 6)
            {
                missions.Add(new Mission(missionNumber, GetTeamSize(missionNumber, numberOfPlayers)));
            }

            return missions;
        }


        private int GetTeamSize(int missionNumber, int numberOfplayers)
        {
            return numberOfplayers switch
            {
                5 => GetFivePlayerMissionSize(missionNumber),
                6 => GetSixPlayerMissionSize(missionNumber),
                7 => GetSevenPlayerMissionSize(missionNumber),
                8 => GetEightPlayerMissionSize(missionNumber),
                9 => GetNinePlayerMissionSize(missionNumber),
                10 => GetTenPlayerMissionSize(missionNumber),
                11 => GetElevenPlayerMissionSize(missionNumber),
                _ => 1,
            };
        }

        private int GetFivePlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 2,
                2 => 3,
                3 => 2,
                4 => 3,
                5 => 3,
                _ => throw new Exception(),
            };
        }

        private int GetSixPlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 2,
                2 => 3,
                3 => 4,
                4 => 3,
                5 => 4,
                _ => throw new Exception(),
            };
        }

        private int GetSevenPlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 2,
                2 => 3,
                3 => 3,
                4 => 4,
                5 => 4,
                _ => throw new Exception(),
            };
        }

        private int GetEightPlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 3,
                2 => 4,
                3 => 4,
                4 => 5,
                5 => 5,
                _ => throw new Exception(),
            };
        }

        private int GetNinePlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 3,
                2 => 4,
                3 => 4,
                4 => 5,
                5 => 5,
                _ => throw new Exception(),
            };
        }

        private int GetTenPlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 3,
                2 => 4,
                3 => 4,
                4 => 5,
                5 => 5,
                _ => throw new Exception(),
            };
        }

        private int GetElevenPlayerMissionSize(int missionNumber)
        {
            return missionNumber switch
            {
                1 => 3,
                2 => 4,
                3 => 5,
                4 => 6,
                5 => 6,
                _ => throw new Exception(),
            };
        }
    }
}
