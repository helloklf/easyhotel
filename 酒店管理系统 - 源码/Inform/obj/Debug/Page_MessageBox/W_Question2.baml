   M S B A M L   `   `   `  ����A  =Inform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Project_Term2Project_Term2  5   L   /    )Project_Term2.Page_MessageBox.W_Question2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   (myclr-namespace:Project_Term2    6L   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
MainColors��5   .    �� InputLanguage$ EN-US��5   =    � WindowStartupLocation$ CenterScreen=�5   	   $��5q�5   i    � Title$ 消息��5   	   $	��240��6   $	��320��6!    � AllowsTransparency .  � WindowStyle$
 None=�6G    � WindowState$ Normal=�6Z   ��5   	   �� *
Foreground+ �� ElementName$ C����69   �� *
Background+$ C����6}   �� *
Background+$ C�� � 	Resources 5      	 �� Source�� 5   
   $	 TopButStyle.xaml?�6   %    69   .��5
      � -   5        $��Grid_��5
      
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5           	TopBorder#��[  5   (   ���	#3F000000��6K   �� *
Foreground+$ C��._�5      ]� .+�5      �� -   5         ��Name$ C��5      $y�	Collapsed=�6%   ��6<   �� *
Foreground+$ C����6l   �� *	BgColor+6�   �� 5      -   5        $��Right=�5   1    � ToolTip$ 关闭��6H    
 TopBut#��[ 6U   ._�5      �� $��../Image/ICON0/叉.png��6   6<   5      �� 5      -   5        $y�	Collapsed=�5      $ 最大化/自动��60   #��[ 6W   ._�5      �� $"��../Image/ICON0/显示器.png��6   6>   5      �� 5      -   5        $ 	最小化��5      #��[ 6>   ._�5      �� $��../Image/ICON0/下.png��6   6<   5      �� 5       -   5        .��5!      �� -	   5        $��	TitleText��5!       $��	　　　��61   $��Center=�6<   
������� �� TextAlignment$ Center=�6j   $��20(�6�    �� Padding$ 0,5,0,0q�6�   $3 -双击缩放窗口，按住鼠标移动窗口��6�    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#      5$   .   5%      5&      5'      �� 5)   
   -
   5        $��MessageText��5)      $��1��6'   $��0q�64   $
��Wrap=�6?   $��15(�6S   ��6a   �� *
Foreground+$ C����6�   �� *
Background+$ C��6�   ]� 5*   
   ��.  $��2��6*   .+�5+      �� -   5        $��Right=�5+   0   $	 是��6G     Submit_Smalllab#��[ 6S   $��0q�6�   ��6|   Z� .��5,      �� $��../Image/ICON0/勾.png��6   68   5-      �� 5.      -   5        $��Right=�5.   /   $	 否��6F   #��[ 6R   $��0q�6�   ��6{   Z� .��5/      �� $��../Image/ICON0/叉.png��6   68   50      �� 51      -   5        $��Right=�51   1   $ 返回��6H   #��[ 6U   $��0q�6�   ��6~   Z� .��52      �� $��../Image/ICON0/左.png��6   68   53      54      55      56      