   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5      Q MProject_Term2_RoomList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Project_Term2_RoomListProject_Term2_RoomList 5   =   '   !Project_Term2_RoomList.PageManage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6:   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <myc,clr-namespace:MyControls;assembly=MyControls     5      3my$clr-namespace:Project_Term2_RoomList     5   =   -   5          >�Name$
  this��5      $��Stretch=�5      $��Stretch=�5      ���#3555 � 	Resources 5	       �� Source�� 5
   
   $ 
Style.xaml?�6   %    63   .��5      ]�    PageManagePanel#��[  6   .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   -   5         ��Name$ 
Left_Right��5      $��Right=�6$   $��o��6;   $��20��6G   $��Center=�6U    J� Opacity$	 0.7Q�6w   $��0,0,2,0q�6�   ��6�   �� *
Background+ �� ElementName$ C��6�   ]� 5   
   $
��Left=�6   .+�5      ]� -   5         ]�Name$ LeftMenu��5      $��25,20,25,10q�6*   .+�5      ]� $	��Top=�6   .+�5         MyControls.Retreat  -   5        $��Center=�5   H   $
��Left=�6c   6{   �� 5      -   5        $��房间管理��5       $
��Left=�6,   $��45(�6G   $	��160��6U   $��15q�6d   ��6�   �� *
Foreground+$ C��6�   5      �� 5      $��60,0,0,0q�6   $��Disabled=�61   $��Hidden=�6Z   .��5      � -   5         �Name$ ML��5        5         MyControls.MenuItem	 �� 
TargetType
 �� Property �� Value��%�   '        �� 5      "	  6$   .�5   "   �� 
 � ��$	 240��6:   6H   �� 5   "   
 � ��$	 135��6;   6I   �� 5   "   
 � �� 6?   �� *
Foreground+$
 this��6o   5      5       .+�5!        -   5          Name$ R2��5!   3   ���	#FFFBFBA4   ItemBackground$" pages/Image/添加房间.jpg��6V      	ItemTitle$ 添加房间��6|   6�     5"      -	   5        $ r3��5"   3   ���	#FF6FB61A$ pages/Image/房间.jpg��6V   $ 查看房间��6z   6�     5#      -
   5        $ r4��5#   3   ���	#FFC0D300$ pages/Image/刷漆.jpg��6V   $ 修改房间��6z   6�   5$      5%      5&      5'      ]� 5*   
   -   5        $ 	RightMenu��5*      $	��Top=�6'   $y�	Collapsed=�6<   $��25,20,25,10q�6S   .+�5+      ]� $	��Top=�6   .+�5,        -   5        $��Center=�5,   5   $
��Left=�6P   6h   �� 5-      -   5         ��Name$ 	PageTitle��5-      $��房间管理��6/   $
��Left=�6;   $��45(�6V   $	��160��6d   $��15q�6s   ��6�   �� *
Foreground+$ C��6�   5.      �� 5/      -   5        $	��Tab��50   +   |�.  $��Right=�5/   +   $��0q�6B   $��0q�50   6   ��5/   V   Z� ��50      Z� .@�52      �� 54      �� 55      .��56      $  Project_Term2_RoomList.RoomAdd  6#   57      �� 58      .��59      '  !Project_Term2_RoomList.RoomSelect  6&   5:      5<      5=      5?      5@      