/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID GAMEPLAY_THEME = 391042987U;
        static const AkUniqueID MENU_BUTTON_PRESS = 952003163U;
        static const AkUniqueID MORT_ATTACK = 4211465302U;
        static const AkUniqueID MORT_DAMAGE = 348163457U;
        static const AkUniqueID MORT_JUMP = 3154367434U;
        static const AkUniqueID MORT_LAND = 3792100141U;
        static const AkUniqueID PRESS_SWITCH = 4156760537U;
        static const AkUniqueID VITA_JUMP = 2975984098U;
        static const AkUniqueID VITA_LAND = 4150497509U;
        static const AkUniqueID ZOMBIE_ATTACK = 3473319566U;
        static const AkUniqueID ZOMBIE_DEATH = 2474416884U;
        static const AkUniqueID ZOMBIE_HURT = 1361217281U;
        static const AkUniqueID ZOMBIE_IDLE = 3548089160U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace CHARACTER_SWITCH
        {
            static const AkUniqueID GROUP = 1085373737U;

            namespace STATE
            {
                static const AkUniqueID MORT_STATE = 6420585U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID VITA_STATE = 2869933681U;
            } // namespace STATE
        } // namespace CHARACTER_SWITCH

        namespace MENU
        {
            static const AkUniqueID GROUP = 2607556080U;

            namespace STATE
            {
                static const AkUniqueID MENU_CLOSED = 1557918927U;
                static const AkUniqueID MENU_OPEN = 1287511387U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MENU

        namespace MONSTERS
        {
            static const AkUniqueID GROUP = 3858746980U;

            namespace STATE
            {
                static const AkUniqueID MONSTER_AWARE = 290496626U;
                static const AkUniqueID MONSTER_UNAWARE = 3000363985U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MONSTERS

        namespace PLAYERLIFE
        {
            static const AkUniqueID GROUP = 444815956U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYERLIFE

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID INSIDE_OUTSIDE = 1601474789U;
        static const AkUniqueID PLAYER_HEALTH = 215992295U;
        static const AkUniqueID PLAYERSIZE = 4258827653U;
        static const AkUniqueID SS_AIR_FEAR = 1351367891U;
        static const AkUniqueID SS_AIR_FREEFALL = 3002758120U;
        static const AkUniqueID SS_AIR_FURY = 1029930033U;
        static const AkUniqueID SS_AIR_MONTH = 2648548617U;
        static const AkUniqueID SS_AIR_PRESENCE = 3847924954U;
        static const AkUniqueID SS_AIR_RPM = 822163944U;
        static const AkUniqueID SS_AIR_SIZE = 3074696722U;
        static const AkUniqueID SS_AIR_STORM = 3715662592U;
        static const AkUniqueID SS_AIR_TIMEOFDAY = 3203397129U;
        static const AkUniqueID SS_AIR_TURBULENCE = 4160247818U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID MORT_DEATH = 3251561164U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
