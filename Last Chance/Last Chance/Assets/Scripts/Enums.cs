using UnityEngine;

public class Enums : MonoBehaviour {

    public enum Scenes { MainMenu, NewGame, LoadGame, SaveGame, GameOver, Base, Map, Castle }
    public enum Group { Ally, Enemy, Monster, Last }
    public enum Class { Soldier, BlackMage, WhiteMage }
    public enum Attr { Str, End, Agi, Int, Spi, Cha, Lck, All };
    public enum Elements { Physical, Healing, Fire, Lightning, Ice, Earth, Wind, Holy, Dark }

    public enum ID { Attack, Cure, Fire, Thunder, Blizzard, Quake, Aero, Holy }

}
