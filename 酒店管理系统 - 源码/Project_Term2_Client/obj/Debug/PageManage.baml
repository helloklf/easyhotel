   M S B A M L   `   `   `  ����O  KProject_Term2_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_Term2_ClientProject_Term2_Client  5      E AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls 5      ;"clr-namespace:Project_Term2_ClientProject_Term2_Client  5   m   %    Project_Term2_Client.PageManage   5      ,local"clr-namespace:Project_Term2_Client  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <myc,clr-namespace:MyControls;assembly=MyControls     5      1my"clr-namespace:Project_Term2_Client     5   m   -   5          >�Name$
  this��5   8   $��Stretch=�5       $��Stretch=�6>   ���#3555 � 	Resources 5	       �� Source�� 5
   
   $ 
Style.xaml?�6   %    63   .��5      ]�    PageManagePanel#��[  6   .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   -   5         ��Name$ 
Left_Right��5      $��Right=�6$   $��o��6;   $��20��6G   $��Center=�6U    J� Opacity$	 0.7Q�6w   $��0,0,2,0q�6�   ��6�   �� *
Background+ �� ElementName$ C��6�   ]� 5   
   $	��Top=�6   .+�5      ]� -   5         ]�Name$ LeftMenu��5      $��25,20,25,10q�6*   .+�5      ]� $	��Top=�6   .+�5        MyControls.Retreat  -   5        $��Center=�5   H   $
��Left=�6c   6{   �� 5      -   5        $��客户中心��5       $
��Left=�6,   $��45(�6G   $	��160��6U   $��15q�6d   ��6�   �� *
Foreground+$ C��6�   5      �� 5      $��60,0,0,0q�6   $��Disabled=�61   $��Hidden=�6Z   |�.  .��5      � -   5         �Name$ ML��5       |�.   5        MyControls.MenuItem	 �� 
TargetType
 �� Property �� Value��%�   '        �� 5      "	  6$   .�5   "   �� 
 � ��$	 240��6:   6H   �� 5   "   
 � ��$	 135��6;   6I   �� 5   "   
 � �� 6?   �� *
Foreground+$
 this��6o   5      5      .+�5         -   5        
�������   ItemBackground$ pages/Image/head.png��5    F      	ItemTitle$ 客户管理��6l   6     5!      -	   5        ���	#FFA00505$ pages/Image/黄金VIP.jpg��5!   J   $ 
VIP 管理��6q   6�   5"      5#      5$      5%      ]� 5&   
   -
   5        $ 	RightMenu��5&      $	��Top=�6'   $y�	Collapsed=�6<   $��25,20,25,10q�6S   .+�5'      ]� $	��Top=�6   .+�5(        -   5        $��Center=�5(   5   $
��Left=�6P   6h   �� 5)      -   5         ��Name$ 	PageTitle��5)      $��客户中心��6/   $
��Left=�6;   $��45(�6V   $	��160��6d   $��15q�6s   ��6�   �� *
Foreground+$ C��6�   5*      �� 5+      -   5        $	��Tab��5,   +   |�.  $��Right=�5+   +   $��0q�6B   $��0q�5,   6   ��5+   V   Z� ��5,      Z� .@�5.      �� .��5/      #   Project_Term2_Client.HelpInfo  6'   50      �� 51      .��52      %   Project_Term2_Client.ClientList  6&   53      �� 54      .��55      "   Project_Term2_Client.VIPList  6#   56      57      58      59      5:      