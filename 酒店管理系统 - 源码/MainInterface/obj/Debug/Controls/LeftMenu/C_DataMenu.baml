   M S B A M L   `   `   `  ����   酒店管理系统-主程序'    !Project_Term2.LeftMenu.C_DataMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $	��180��5        � 	Resources  5       �� Source�� 5   
   $ 
Style.xaml?�6   %    63   .��5
      ]� -   5        $��MainMenu_Left��5
      
 � Tag$
 true��6%      SmallPage_LeftList#��[  6F   $	��180��6r   $��0q�6~   ��60   Z� .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   $��	菜　单��6     LeftList_Title#��[ 6   6I   �� 5   
   -   5        $	��Top=�5        MenuList#��[ 6%   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $J��D/酒店管理系统-主程序;component/Controls/Image/ICON0/层.png��6   6T   �� 5      $��主 菜 单��6   $��Center=�6)   6F   5      5      �� 5   
   -   5         ��Name$ AdministratorItem��5   *   $	��Top=�6   $y�	Collapsed=�6E   .+�5      �� $��2��6   $	��Top=�6    $��
20,5,20,10q�6e    J� Opacity$	 0.5Q�6y   ��65   �� *
Foreground+ �� ElementName$ C��6�   �� 5      -   5        #��[ 5      .��5      �� $ 
Horizontal=�6   .+�5      �� $��40��6   $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/钥匙.png��6#   6`   �� 5      $��入住登记��6   $��Center=�6(   6E   5      5      �� 5      -   5        #��[ 5      .��5      �� $ 
Horizontal=�6   .+�5      �� $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/下楼.png��6   6Y   �� 5      $��退房结账��6    $��Center=�6,   6I   5       5!      �� 5"      -   5        #��[ 5"      .��5#      �� $ 
Horizontal=�6   .+�5$      �� $��40��6   $P��J/酒店管理系统-主程序;component/Controls/Image/ICON0/人民币.png��6'   6e   �� 5%      $��客户交费��6    $��Center=�6,   6I   5&      5'      �� 5(      -	   5        #��[ 5(      .��5)      �� $ 
Horizontal=�6   .+�5*      �� $��40��6   $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/飞机.png��6'   6d   �� 5+      $��预订房间��6    $��Center=�6,   6I   5,      5-      �� 5.      -
   5        #��[ 5.      .��5/      �� $ 
Horizontal=�6   .+�50      �� $��40��6   $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/宫格.png��6'   6d   �� 51      $��房间列表��6    $��Center=�6,   6I   52      53      �� 54      $��2��6   $	��Top=�6    $��
20,5,20,10q�6e   $	 0.5Q�6y   ��65   �� *
Foreground+$ C��6�   �� 55      -   5        #��[ 55      .��56      �� $ 
Horizontal=�6   .+�57      �� $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/人群.png��6   6Y   �� 58      $��客户中心��6    $��Center=�6,   6I   59      5:      5;      �� 5=   
   -   5        $ AdvAdminiItem��5=   *   $	��Top=�6   $y�	Collapsed=�6A   .+�5>      �� $��2��6   $	��Top=�6    $��
20,5,20,10q�6e   $	 0.5Q�6y   ��65   �� *
Foreground+$ C��6�   �� 5?      -   5        #��[ 5?      .��5@      �� $ 
Horizontal=�6   .+�5A      �� $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/用户.png��6   6Y   �� 5B      $��员工管理��6    $��Center=�6,   6I   5C      5D      �� 5E      -   5        #��[ 5E      .��5F      �� $ 
Horizontal=�6   .+�5G      �� $M��G/酒店管理系统-主程序;component/Controls/Image/ICON0/房屋.png��6   6Y   �� 5H      $��房间管理��6    $��Center=�6,   6I   5I      5J      5K      �� 5M   
   -   5        $ SuperAdminiItem��5M   *   $	��Top=�6   $y�	Collapsed=�6C   .+�5N      �� $��2��6   $	��Top=�6    $��
20,5,20,10q�6e   $	 0.5Q�6y   ��65   �� *
Foreground+$ C��6�   �� 5O      -   5        #��[ 5O      .��5P      �� $ 
Horizontal=�6   .+�5Q      �� $I��C/酒店管理系统-主程序;component/Controls/Image/ICON0/DB.png��6   6Y   �� 5R      $��基础数据��6    $��Center=�6,   6I   5S      5T      5U      5V      5W      