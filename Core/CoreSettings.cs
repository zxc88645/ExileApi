using System.Collections.Generic;
using System.Windows.Forms;
using ExileCore.RenderQ;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace ExileCore
{
    public class CoreSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);


        #region main
        [Menu("Main", 1000)]
        public EmptyNode EmptyMain { get; set; } = new EmptyNode();
        [Menu("刷新區域。", 1, 1000)]
        public ButtonNode RefreshArea { get; set; } = new ButtonNode();
        [Menu("清單設定檔。", "當前無法正常工作。很快。", 2, 1000)]
        public ListNode Profiles { get; set; } = new ListNode { Values = new List<string> { "global" }, Value = "global" };
        [Menu("功能表鍵切換。", 3, 1000)]
        public HotkeyNode MainMenuKeyToggle { get; set; } = Keys.F12;
        [Menu("強制置頂。", 4, 1000)]
        public ToggleNode ForceForeground { get; set; } = new ToggleNode(false);
        [Menu("自動下載更新。", 5, 1000)]
        public ToggleNode AutoPrepareUpdate { get; set; } = new ToggleNode(true);
        #endregion

        #region messages
        [Menu("Messages", 2000)]
        public EmptyNode EmptyMessages { get; set; } = new EmptyNode();
        [Menu("啟用資訊消息。", "將始終顯示在日誌視窗中。", 1, 2000)]
        public ToggleNode ShowInformationMessages { get; set; } = new ToggleNode(true);
        [Menu("啟用錯誤消息。", "將始終顯示在日誌視窗中。", 2, 2000)]
        public ToggleNode ShowErrorMessages { get; set; } = new ToggleNode(true);
        [Menu("啟用調試消息。", "(De)也啟動日誌視窗中的條目。", 3, 2000)]
        public ToggleNode ShowDebugMessages { get; set; } = new ToggleNode(false);
        [Menu("顯示日誌視窗。", 4, 2000)]
        public ToggleNode ShowDebugLog { get; set; } = new ToggleNode(false);
        [Menu("顯示調試視窗。", 5, 2000)]
        public ToggleNode ShowDebugWindow { get; set; } = new ToggleNode(false);
        [Menu("調試資訊。", "使用這個選項,您可以檢查每個外掛程式的工作方式。.", 6, 2000)]
        public ToggleNode CollectDebugInformation { get; set; } = new ToggleNode(false);
        [Menu("日誌讀取記憶體錯誤。", 7, 2000)]
        public ToggleNode LogReadMemoryError { get; set; } = new ToggleNode(false);
        #endregion

        #region performance
        [Menu("性能。", 3000)]
        public EmptyNode EmptyPerfomance { get; set; } = new EmptyNode();
        [Menu("線程計數。", 1, 3000)]
        public RangeNode<int> Threads { get; set; } = new RangeNode<int>(1, 0, 4);
        [Menu("HUD VSync", 2, 3000)]
        public ToggleNode VSync { get; set; } = new ToggleNode(false);
        [Menu("動態。 FPS", "Hud FPS like FPS game", 3, 3000)]

        public ToggleNode DynamicFPS { get; set; } = new ToggleNode(false);
        [Menu("Percent 從遊戲。 FPS", 4, 3000)]
        public RangeNode<int> DynamicPercent { get; set; } = new RangeNode<int>(100, 1, 150);
        [Menu("動態時最少的 FPS。", 5, 3000)]
        public RangeNode<int> MinimalFpsForDynamic { get; set; } = new RangeNode<int>(60, 10, 150);

        [Menu("目標。 FPS", 6, 3000)]
        public RangeNode<int> TargetFps { get; set; } = new RangeNode<int>(60, 5, 200);
        [Menu("目標平行腐蝕。 Fps", 7, 3000)]
        public RangeNode<int> TargetParallelFPS { get; set; } = new RangeNode<int>(60, 30, 500);
        [Menu("Entites FPS", "需要如何經常更新實體。您可以在除錯視窗看到。->Coroutines 時間花了什麼工作。", 8, 3000)]
        public RangeNode<int> EntitiesUpdate { get; set; } = new RangeNode<int>(60, 5, 200);
        [Menu("解析伺服器實體。", 10, 3000)]
        public ToggleNode ParseServerEntities { get; set; } = new ToggleNode(false);
        [Menu("在超過。 X", 11, 3000)]
        public ToggleNode CollectEntitiesInParallelWhenMoreThanX { get; set; } = new ToggleNode(false);
        [Menu("在ms中限制繪製圖。",
            "不要把小值,因為繪圖需要很多三角形和調試視窗與很多情節將被打破。", 12, 3000)]
        public RangeNode<float> LimitDrawPlot { get; set; } = new RangeNode<float>(0.2f, 0.05f, 20f);
        [Menu("如果外掛程式渲染工作超過 X ms, 消息。", 13, 3000)]
        public RangeNode<int> CriticalTimeForPlugin { get; set; } = new RangeNode<int>(100, 1, 2000);
        #endregion

        #region multithread
        [Menu("多線程", 4000)]
        public EmptyNode EmptyMultithread { get; set; } = new EmptyNode();
        [Menu("加載插件多線程", 1, 4000)]
        public ToggleNode MultiThreadLoadPlugins { get; set; } = new ToggleNode(false);
        [Menu("協程 多線程", "", 2, 4000)]
        public ToggleNode CoroutineMultiThreading { get; set; } = new ToggleNode(true);
        [Menu("實體多線程", 3, 4000)]
        public ToggleNode AddedMultiThread { get; set; } = new ToggleNode(false);
        [Menu("解析多線程", 4, 4000)]
        public ToggleNode ParseEntitiesInMultiThread { get; set; } = new ToggleNode(false);
        #endregion

        #region miscellaneous
        [Menu("Miscellaneous", 5000)]
        public EmptyNode EmptyMiscellaneous { get; set; } = new EmptyNode();
        [Menu("Font", 1, 5000)]
        public ListNode Font { get; set; } = new ListNode { Values = new List<string> { "Not found" } };
        [IgnoreMenu] // "Currently not works. Because this option broke calculate how much pixels needs for render."
        public RangeNode<int> FontSize { get; set; } = new RangeNode<int>(13, 7, 36);
        [Menu("Volume", 3, 5000)]
        public RangeNode<int> Volume { get; set; } = new RangeNode<int>(100, 0, 100);
        #endregion
    }
}
