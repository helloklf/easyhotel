   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5      Q MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Project_Term2_BaseDataProject_Term2_BaseData 5      K*clr-namespace:Project_Term2_BaseData.PagesProject_Term2_BaseData.Pages 5      '   !Project_Term2_BaseData.PageManage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;my,clr-namespace:MyControls;assembly=MyControls     5      6local$clr-namespace:Project_Term2_BaseData     5      :my2*clr-namespace:Project_Term2_BaseData.Pages     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  this��5      ���#3555 � 	Resources 5	       �� Source�� 5
   
   $ 
Style.xaml?�6   %    63   .��5      ]�    PageManagePanel#��[  6   .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   -   5         ��Name$ 
Left_Right��5      $��Right=�6$   $��o��6;   $��20��6G   $��Center=�6U    J� Opacity$	 0.7Q�6w   $��0,0,2,0q�6�   ��6�   �� *
Background+ �� ElementName$ C��6�   ]� 5   
   -   5         ]�Name$ LeftMenu��5   )   $	��Top=�6   $��25,20,25,10q�6;   .+�5      ]� $	��Top=�6   .+�5         MyControls.Retreat  -   5        $��Center=�5   C   $
��Left=�6^   6v   �� 5      -   5        $��基础数据��5      $
��Left=�6(   $��45(�6C   $	��160��6Q   $��15q�6`   ��6�   �� *
Foreground+$ C��6�   5      �� 5      $	��Top=�6   $��60,0,0,0q�60   $��Disabled=�5      $��Hidden=�6D   .��5      � -   5         �Name$ ML��5       5         MyControls.MenuItem	 �� 
TargetType
 �� Property �� Value��%�   '        �� 5      "	  6    .�5      �� 
 � ��$	 240��66   6D   �� 5       
 � ��$	 135��67   6E   �� 5!      
 � �� 6;   �� *
Foreground+$
 this��6k   5"      5#      .+�5$        -   5           	ItemTitle$ 证件类型��5$   "      ItemBackground$! Pages/Tile/证件类型.jpg��63   6f     5%      -	   5        $ 国家列表��5%   "   $! Pages/Tile/国家列表.jpg��63   6f     5&      -
   5        $ 	VIP分级��5&   "   $ Pages/Tile/VIP分级.jpg��64   6h     5'      -   5          Name$ R4��5'   "   $ 授权级别��6.   $! Pages/Tile/授权级别.png��6?   
��� ���6�     5(      -   5        $ 房间类型��5(   "   $! Pages/Tile/房间类型.jpg��63   6f     5)      -   5        $ 房间状态��5)   "   $! Pages/Tile/房间状态.png��63   ���	#FFAC0C0C6}     5*      -   5        $ 操作类型��5*   "   $! Pages/Tile/操作类型.jpg��63   6f     5.      -   5        $ 职务类型��5.   "   $! Pages/Tile/职务类型.png��63   ���	#FF00A9E86~   5/      50      51      ]� 54   
   -   5        $ 	RightMenu��54      $	��Top=�6'   $y�	Collapsed=�6<   $��25,20,25,10q�6S   .+�55      ]� $	��Top=�6   .+�56        -   5        $��Center=�56   4   $
��Left=�6O   6g   �� 57      -   5         ��Name$ 	PageTitle��57      $��基础数据��6/   $
��Left=�6;   $��45(�6V   $	��160��6d   $��15q�6s   ��6�   �� *
Foreground+$ C��6�   58      �� 59      -   5        $	��Tab��5:      |�.  $��0q�59   +   $��0q�5:   $   ��59   ?   Z� ��6V   Z� .@�5<      �� .��5=      %  Project_Term2_BaseData.HelpInfo  6'   5>      �� 5A      .��5B      -  'Project_Term2_BaseData.Pages.PapersPage  6'   5C      �� 5F      .��5G      .  (Project_Term2_BaseData.Pages.CountryInfo  6(   5H      �� 5K      .��5L      +  %Project_Term2_BaseData.Pages.VipLevel  6%   5M      �� 5P      .��5Q      /  )Project_Term2_BaseData.Pages.AccreditType  6)   5R      �� 5U      .��5V      +  %Project_Term2_BaseData.Pages.RoomType  6%   5W      �� 5Z      .��5[      0	  *Project_Term2_BaseData.Pages.RoomStateType	  6*   5\      �� 5_      .��5`      .
  (Project_Term2_BaseData.Pages.OperateType
  6(   5a      �� 5d      5f      �� 5i      5k      �� 5n      5p      �� 5s      .��5t      ,  &Project_Term2_BaseData.Pages.StaffType  6&   5u      5w      5x      5y      5z      