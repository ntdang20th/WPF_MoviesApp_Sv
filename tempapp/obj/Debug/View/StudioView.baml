   M S B A M L   `   `   `  ????B  >tempapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:tempapp.Viewtempapp.View  5      5clr-namespace:tempapp.ViewModeltempapp.ViewModel  5          tempapp.View.StudioView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:tempapp.View     5      5	viewModelclr-namespace:tempapp.ViewModel     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
???   ????#E0FBFC  ? DataContext  5      '  !tempapp.ViewModel.StudioViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??80 ?6   ?? 5      $
??auto ?6   ?? 5      $	??100 ?6   ?? 5      .+?5   
   ? $??0??6   .+?5      ?? $??0??6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Studio??5          
Foreground
 ?   ?.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ?   ? %  !MaterialDesignFloatingHintTextBox#??[  5#      $??Center=?5$      $??15(?5%      $??20 10 20 10q?5&      $??Bottom=?5'      ??5(      ?? *DisplayName+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? Mode$ TwoWay=?5)      ? 5*   
   $??1??6   .+?5+      ?? $??0??6   $ Ghi chú??5,      
 ?   ?
 ?   ?#??[  5/      $??Center=?50      $??15(?51      $??20 10 20 10q?52      $	??Top=?53       ?? TextWrapping$
 Wrap=?54      ??55      ?? *GhiChu+$ PropertyChanged=?$ TwoWay=?56      ? 59   
   $??2??6   .+?5:      ?  ? ColumnDefinitions 5;      ?? 5<      ?? 5=      $	??200 ?6'   ?? 5>      $	??200 ?6'   ?? 5?      $	??200 ?6'   .+?5B      ?? -   5        $??	txtSearch??5S      $??0??5B      $	??300??5C      $??50??5D      $??15 5 5 5q?5E      $??Center=?5F      $??Center=?5G      $??Center=?5H      $??0 0 0 0q?5I      $??15(?5J      	   TextFieldCornerRadius$	 15??5K      
   
Background
 ?#E0FBFC   HelperTextFontSize$ 15Q?5M       ! MaterialDesignOutlinedTextBox#??[ 5N       ?? AcceptsReturn . $
 Wrap=?5P      " ?? VerticalScrollBarVisibility$
 Auto=?5Q      $ Search??5R      .??5S   +    J? InputBindings 5T      ?? 5U      
 ?? Key$ Return??5W   %    ?? Command 5U   %   ?? *EnterCommand+ ?? CommandParameter 5V   %   ??  ?? ElementName$ 	txtSearch??5W   %   .??5X   -   5Z      ?? 5_      $??1??6   ???#9DB4C0???#9DB4C0
???   ?  MaterialDesignRaisedButton#??[ 5c      $??50??5d      $	??100??5e      $??Center=?5f      $??Center=?5g      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5h      ??5i      ?? *Them_Command+.??5j      ?? $??Thêm??6    $??20(?6,   5k      ?? 5m      $??2??6   ???#9DB4C0???#9DB4C0
???   ? ? ToolTip$p jCHÚ Ý: Thao tác này sẽ đặt CHỦ ĐỀ của các bộ phim liên quan về trạng thái NULL!!!??5q      #??[ 5r      $??50??5s      $	??100??5t      $??50 10 30 10q?5u      $??Center=?5v      $??Center=?5w      $ 10??5x      ??5y      ?? *Xoa_Command+.??5z      ?? $
??Xóa??6    $??20(?6+   5{      ?? 5}      $??3??6   ???#9DB4C0???#9DB4C0
???   ?#??[ 5?      $??50??5?      $	??100??5?      $??50 10 30 10q?5?      $??Center=?5?      $??Center=?5?      $ 10??5?      ??5?      ?? *Sua_Command+.??5?      ?? $??Sửa??6    $??20(?6+   5?      5?      5?      ? 5?   
   $??3??6   .+?5?      ?? ??6   ?? *
ListStudio+ ?? SelectedItem 6:   ?? *SelectedItem+$ OneWayToSource=? ?? View 5?      ?? 5?      .P?5?      ?? $??ID??6)    ?? DisplayMemberBinding 66   ?? *Id+?? 5?      $??Tên Studio??6)    6>   ?? *	TenStudio+?? 5?       ?? Width$	 550??6)   $??Ghi chú??65    6F   ?? *GhiChu+5?      5?      5?      5?      5?      5?      