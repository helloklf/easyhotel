   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5       Project_Term2_Client"   Project_Term2_Client.VIPList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;my,clr-namespace:MyControls;assembly=MyControls     5      -   5          � 	Resources  5       �� Source�� 5	   
   $ ../Style.xaml?�6   %    .��5      ]� .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��66   �� *	ForeColor+��6W   �� *	BgColor+�� 5   
   $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $
��10,5q�6C   .+�5      �� $��2q�6E    �� Padding$ 0q�6P   ��6   �� *
Background+ �� ElementName$ C��._�5      �� -   5         ��Name$ IsCheck��5   V   $��5q�6      IsEnabel#��[  6~   ��6&   �� *
Foreground+$ C��6�   5         MyControls.RestoreBtn  5      -   5        $��50��5      6J      MyControls.DeleteBtn  5      -   5        $��50��5      6K   5      �� 5   
   $��2��6   $	��Top=�6    J� Opacity$	 0.6Q�61   $
��2,10q�6?   ��6M   �� *
Background+$ C��6   ]� 5   
   .+�5      ]� $��Right=�6   .+�5      �� -   5        $��o��5      $��20��6$   $��Center=�62   $	 0.7Q�6T   $��0,0,1,0q�6b   ��6|   �� *
Foreground+$ C��6�   �� 5      $��Disabled=�6   $��Hidden=�6H   .��5      �� -   5        $��
RightPanel��5   b   $��0q�68   ��6!   Z� ��6L   Z� .@�5      �� $y�	Collapsed=�6"   $��0q�69   ��6M   Z� .��5      �� $��10q�6)   .+�5   "   �� $	��Top=�6,   $��
新增 VIP��6A   $��25(�6O   $��	0,5,10,10q�6]   ��6p   �� *
Foreground+$ C��6�   ]� 5   "   $��2q�6,   .+�5    &   �� $��VIP编号*：��60     	LeftTitle#��[ 6?   6d   �� 5!   &   -   5        $��InText��5!   .    � ToolTip$/ )VIP编号(15字以内)，如:V20140805001��6<     ShortTextBox#��[ 6b   5"   #      MyControls.OK  5#   "   -	   5        $��Right=�5#   D   $
��10,5q�6`   6p   5$      5%      5&      5'      5(      ]� 5*      $��5q�6   $	��Top=�6#   .+�5+      �� -
   5        	 ��Name$	 LB��5+      
 �� SelectedValuePath$
 VIPID��6&   ��6@   �� ��5,      �� 5-      .R�5.      � 6*   5/      ��51      �� 52      .R�53      ]� ���#FFFFCC$	��350��6=   .+�54   "   �� $��10q�6-   $ 
Horizontal=�69   .+�55   &   �� $��Center=�60   VIP编号：6S   �� 56   &   $��Center=�60    �� Padding$ 2q�6b   ��6K   �� *VIPID+6p   �� 57   &   $��20,0,0,0q�60   $��Center=�6B   	积分：6b   �� 58   &   $��Center=�60   $ 2q�6h   ��6K   �� *VIPIntegral+6v   �� 59   &   $��20,0,0,0q�60   $��Center=�6B   有效性：6c   �� 5:   &   $��Center=�60   $ 2q�6h   ��6K   �� *IsValidText+6v   5;   #   5<      5=      5?      5@      5A      5B      5C      