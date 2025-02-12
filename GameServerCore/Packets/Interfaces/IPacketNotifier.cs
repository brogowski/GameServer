﻿using System.Collections.Generic;
using System.Numerics;
using GameServerCore.Content;
using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using GameServerCore.NetInfo;
using GameServerCore.Enums;
using GameServerCore.Packets.Enums;
using GameServerCore.Packets.PacketDefinitions.Requests;

namespace GameServerCore.Packets.Interfaces
{
    public interface IPacketNotifier
    {
        void NotifyAddBuff(IBuff b);
        void NotifyAddDebugObject(int userId, IAttackableUnit unit, uint objNetId, float lifetime, float radius, Vector3 pos1, Vector3 pos2, int objID = 0, byte type = 0x0, string name = "debugobj", byte r = 0xFF, byte g = 0x46, byte b = 0x0);
        void NotifyAddGold(IChampion c, IAttackableUnit died, float gold);
        void NotifyAddXp(IChampion champion, float experience);
        void NotifyAnnounceEvent(int mapId, Announces messageId, bool isMapSpecific);
        void NotifyAvatarInfo(int userId, ClientInfo client);
        void NotifyBeginAutoAttack(IAttackableUnit attacker, IAttackableUnit victim, uint futureProjNetId, bool isCritical);
        /// <summary> TODO: tipCommand should be an lib/core enum that gets translated into league version specific packet enum as it may change over time </summary>
        void NotifyBlueTip(int userId, string title, string text, string imagePath, byte tipCommand, uint playerNetId, uint targetNetId);
        void NotifyBuyItem(int userId, IObjAiBase champion, IItem itemInstance);
        void NotifyCastSpell(INavGrid navGrid, ISpell s, Vector2 start, Vector2 end, uint futureProjNetId, uint spellNetId);
        void NotifyChampionDeathTimer(IChampion die);
        void NotifyChampionDie(IChampion die, IAttackableUnit killer, int goldFromKill);
        void NotifyChampionRespawn(IChampion c);
        void NotifyChampionSpawned(IChampion c, TeamId team);
        void NotifyCreateUnitHighlight(int userId, IGameObject unit);
        void NotifyDamageDone(IAttackableUnit source, IAttackableUnit target, float amount, DamageType type, DamageText damagetext, bool isGlobal = true, int sourceId = 0, int targetId = 0);
        void NotifyDash(IAttackableUnit u, ITarget t, float dashSpeed, bool keepFacingLastDirection, float leapHeight, float followTargetMaxDistance, float backDistance, float travelTime);
        void NotifyDebugMessage(string htmlDebugMessage);
        void NotifyDebugMessage(int userId, string message);
        void NotifyDebugMessage(TeamId team, string message);
        // TODO: only in deubg mode
        void NotifyDebugPacket(int userId, byte[] data);
        void NotifyDestroyClientMissile(IProjectile p);
        void NotifyDestroyClientMissile(IProjectile p, TeamId team);
        void NotifyEditBuff(IBuff b, int stacks);
        void NotifyEmotions(Emotions type, uint netId);
        void NotifyEnterLocalVisibilityClient(IAttackableUnit unit, int userId = 0);
        void NotifyEnterLocalVisibilityClient(int userId, uint netId);
        void NotifyEnterVisibilityClient(IAttackableUnit o, TeamId team, int userId = 0);
        void NotifyFaceDirection(IAttackableUnit u, Vector2 direction, bool isInstant = true, float turnTime = 0.0833F);
        void NotifyFogUpdate2(IAttackableUnit u, uint newFogId);
        void NotifyForceCreateMissile(IProjectile p);
        void NotifyFXCreateGroup(IParticle particle, Vector3 direction = new Vector3(), float timespent = 0, bool reqvision = true);
        void NotifyFXEnterTeamVisibility(IParticle particle, TeamId team);
        void NotifyFXKill(IParticle particle);
        void NotifyFXLeaveTeamVisibility(IParticle particle, TeamId team);
        void NotifyGameEnd(Vector3 cameraPosition, INexus nexus, List<Pair<uint, ClientInfo>> players);
        void NotifyGameStart();
        void NotifyGameTimer(float gameTime);
        void NotifyGameTimer(int userId, float time);
        void NotifyGameTimerUpdate(int userId, float time);
        void NotifyHeroSpawn(int userId, ClientInfo client);
        void NotifyHeroSpawn2(int userId, IChampion champion);
        void NotifyInhibitorSpawningSoon(IInhibitor inhibitor);
        void NotifyInhibitorState(IInhibitor inhibitor, IGameObject killer = null, List<IChampion> assists = null);
        void NotifyInstantStopAttack(IAttackableUnit attacker, bool isSummonerSpell, uint missileNetID = 0);
        void NotifyItemsSwapped(IChampion c, byte fromSlot, byte toSlot);
        // TODO: move handling to PacketDefinitions
        void NotifyKeyCheck(ulong userId, uint playerNo);
        void NotifyLaneMinionSpawned(ILaneMinion m, TeamId team);
        void NotifyLeaveVision(IGameObject o, TeamId team);
        void NotifyLevelPropSpawn(int userId, ILevelProp levelProp);
        void NotifyLevelUp(IChampion c);
        void NotifyLoadScreenInfo(int userId, List<Pair<uint, ClientInfo>> players);
        void NotifyLoadScreenPlayerChampion(int userId, Pair<uint, ClientInfo> player);
        void NotifyLoadScreenPlayerName(int userId, Pair<uint, ClientInfo> player);
        void NotifyMinionSpawned(IMinion m, TeamId team);
        void NotifyMissileReplication(IProjectile p);
        void NotifyModelUpdate(IAttackableUnit obj);
        void NotifyModifyDebugCircleRadius(int userId, uint sender, int objID, float newRadius);
        void NotifyModifyDebugObjectColor(int userId, uint sender, int objID, byte r, byte g, byte b);
        void NotifyModifyShield(IAttackableUnit unit, float amount, bool IsPhysical, bool IsMagical, bool StopShieldFade);
        void NotifyMovement(IGameObject o);
        void NotifyNextAutoAttack(IAttackableUnit attacker, IAttackableUnit target, uint futureProjNetId, bool isCritical, bool nextAttackFlag);
        void NotifyNpcDie(IAttackableUnit die, IAttackableUnit killer);
        void NotifyOnAttack(IAttackableUnit attacker, IAttackableUnit attacked, AttackType attackType);
        void NotifyPauseGame(int seconds, bool showWindow);
        void NotifyPing(ClientInfo client, Vector2 position, int targetNetId, Pings type);
        void NotifyPingLoadInfo(PingLoadInfoRequest request, ClientInfo clientInfo);
        void NotifyPlayerStats(IChampion champion);
        void NotifyQueryStatus(int userId);
        void NotifyRemoveBuff(IAttackableUnit u, string buffName, byte slot = 1);
        void NotifyRemoveDebugObject(int userId, uint sender, int objID);
        void NotifyRemoveItem(IChampion c, byte slot, byte remaining);
        void NotifyRemoveUnitHighlight(int userId, IGameObject unit);
        void NotifyResumeGame(IAttackableUnit unpauser, bool showWindow);
        void NotifySetAnimation(IAttackableUnit u, List<string> animationPairs);
        void NotifySetCanSurrender(bool can, TeamId team);
        void NotifySetCooldown(IChampion c, byte slotId, float currentCd, float totalCd);
        void NotifySetDebugHidden(int userId, uint sender, int objID, byte bitfield = 0x0);
        void NotifySetTarget(IAttackableUnit attacker, IAttackableUnit target);
        void NotifySetTeam(IAttackableUnit unit, TeamId team);
        void NotifySkillUp(int userId, uint netId, byte skill, byte level, byte pointsLeft);
        void NotifySpawn(IAttackableUnit u);
        void NotifySpawnEnd(int userId);
        void NotifySpawnStart(int userId);
        void NotifySpellAnimation(IAttackableUnit u, string animation);
        void NotifyStaticObjectSpawn(int userId, uint netId);
        void NotifyTeamSurrenderVote(IChampion starter, bool open, bool votedYes, byte yesVotes, byte noVotes, byte maxVotes, float timeOut);
        void NotifyTeamSurrenderStatus(int userId, TeamId team, SurrenderReason reason, byte yesVotes, byte noVotes);
        void NotifySynchVersion(int userId, List<Pair<uint, ClientInfo>> players, string version, string gameMode, int mapId);
        void NotifyTeleport(IAttackableUnit u, Vector2 pos);
        void NotifyTint(TeamId team, bool enable, float speed, Color color);
        void NotifyTurretSpawn(int userId, ILaneTurret turret);
        void NotifyUnitAnnounceEvent(UnitAnnounces messageId, IAttackableUnit target, IGameObject killer = null, List<IChampion> assists = null);
        void NotifyUnitSetDrawPathMode(int userId, IAttackableUnit unit, IGameObject target, byte mode);
        void NotifyUnpauseGame();
        void NotifyUpdatedStats(IAttackableUnit u, bool partial = true);
        void NotifyViewResponse(int userId, ViewRequest request);
    }
}