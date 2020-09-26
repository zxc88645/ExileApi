using System.Runtime.InteropServices;

namespace GameOffsets
{
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct IngameUElementsOffsets
	{
		[FieldOffset(0x210)] public long GetQuests;	//3.12.1TW
		[FieldOffset(0x238)] public long GameUI; //3.12.1TW

		//**

		[FieldOffset(0x378)] public long Mouse; //3.12.1TW = Cursor
		[FieldOffset(0x380)] public long SkillBar; //3.12.1TW
		[FieldOffset(0x388)] public long HiddenSkillBar; //3.12.1TW

		[FieldOffset(0x398)] public long StickiePartyPanel; //3.12.1TW my

		[FieldOffset(0x3E0)] public long BanditDialog;   //??
		[FieldOffset(0x488)] public long QuestTracker;   //3.12.1TW

		[FieldOffset(0x4F0 /*4F0*/)] public long OpenLeftPanel; //3.12.1TW
		[FieldOffset(0x4F8 /*4F8*/)] public long OpenRightPanel;    //3.12.1TW

		[FieldOffset(0x528)] public long InventoryPanel;    //3.12.1TW
		[FieldOffset(0x530)] public long StashElement;    //3.12.1TW

		[FieldOffset(0x558)] public long TreePanel;	//3.12.1TW
		[FieldOffset(0x560)] public long AtlasPanel;  //3.12.1TW
		[FieldOffset(0x590)] public long WorldMap;    //3.12.1TW


		[FieldOffset(0x5B0)] public long Map;    //3.12.1TW
		[FieldOffset(0x5B8)] public long itemsOnGroundLabelRoot; //3.12.1TW

		[FieldOffset(0x640)] public long NpcDialog; //3.12.1TW

		[FieldOffset(0x658)] public long QuestRewardWindow;  //3.12.1TW
		[FieldOffset(0x660)] public long PurchaseWindow;	//3.12.1TW
		[FieldOffset(0x668)] public long SellWindow;    //3.12.1TW
		[FieldOffset(0x670)] public long TradeWindow;   //3.12.1TW

		[FieldOffset(0x6A8)] public long MapDeviceWindow;   //3.12.1TW

		[FieldOffset(0x700)] public long IncursionWindow;    //3.12.1TW

		[FieldOffset(0x720)] public long DelveWindow;   //3.12.1TW
		[FieldOffset(0x740)] public long BetrayalWindow;    //3.12.1TW
		[FieldOffset(0x748)] public long ZanaMissionChoice; //3.12.1TW
		[FieldOffset(0x758)] public long CraftBenchWindow;	//3.12.1TW
		[FieldOffset(0x760)] public long UnveilWindow;  //3.12.1TW

		[FieldOffset(0x790)] public long SynthesisWindow;   //3.12.1TW
		[FieldOffset(0x7A0)] public long MetamorphWindow;   //3.12.1TW   //器官窗口
		[FieldOffset(0x790)] public long AreaInstanceUi;    //3.12.1TW   

		//----------

		[FieldOffset(0x960)] public long GemLvlUpPanel;    //3.12.1TW

		[FieldOffset(0x918)] public long InvitesPanel;  //?? 被邀請的視窗

		[FieldOffset(0x9C8)] public long ItemOnGroundTooltip;   //??

		[FieldOffset(0x0/*0xF18*/)] public long MapTabWindowStartPtr;//TOFO: Fixme. Cause reading errors
	}
}