   M S B A M L   `   `   `  ????B  >tempapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:tempapp.MyUserCOntroltempapp.MyUserCOntrol  5      (    "tempapp.MyUserCOntrol.ucControlBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:tempapp.MyUserCOntrol     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $??
ControlBar??5
      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown??6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ?? *MouseMoveWindowCommand+   CommandParameter 6O   ??  ?? ElementName$ 
ControlBar??5      .??5      ]? ??.  
??????  ? 	Resources 5   
    ?? 
TargetType ?? Property	 ?? Value
 ?? 
TargetType ?? Triggers P? Property P? Value??%?  '??       ?? 5      " ??6   .?5      ??  ? ??$	 50??6*   ?? 5       ? ??$	 50??6+   ?? 5       ? ??
	 ?????6/   ?? 5       ? ??
	 ???? 6/   ?? 5       ? ??$	 0q?64   ?? 5       ? ??	 5      ?? 5       "
 ??6*   .R?5!      ?? #??z??6%   ._?5"   "   ?? $??Center=?63   $??Center=?6P   5#      5$      5&       5'      P? 5(       ?@J?IsMouseOver . . ?5)      ??  ? ??
	 ?   ?67   5*      5,      5.      .+?51   
   ?? $??Right=?6    ? ToolTip$ Close??54      ??52      ?? *CloseWindowCommand+??53      ?? $ 
ControlBar??.??55      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=?6&   56      ?? 58   
   $??Right=?6   $
 Hide??5;      ??59      ?? *MinimizeWindowCommand+??5:      ?? $ 
ControlBar??.??5<        $ WindowMinimize=?6&   5=      5@      5A      