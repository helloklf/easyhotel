   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5       Project_Term2_Client%   Project_Term2_Client.ClientList   5      3my,clr-namespace:MyControls;assembly=MyControls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          � 	Resources  5       �� Source�� 5	      $ ../Style.xaml?�6   %    .��5      ]� .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v   �� 5   
   $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $
��10,5q�6C   .+�5         MyControls.AddItemBtn  -   5        $��50��5      $y�	Collapsed=�6<   6U   5      �� 5   
   $��2��6   $	��Top=�6    J� Opacity$	 0.6Q�61   $
��2,10q�6?   ��6M   �� *
Background+ �� ElementName$ C��6   ]� 5   
   $��Right=�6   .+�5      �� -   5        $��o��5      $��20��6    $��Center=�6.   $	 0.7Q�6P   $��0,0,1,0q�6^   ��6x   �� *
Foreground+$ C��6�   �� 5      $��Disabled=�6   $��Hidden=�6D   .��5      �� -   5        $��
RightPanel��5   ^   $��0q�64   $y�	Collapsed=�6p   ��6   Z� ��6H   Z� .@�5      �� $y�	Collapsed=�6   $��0q�6L   ��65   Z� ��6`   Z� .��5      �� $��15,10q�6%   $	��400��64   .+�5      �� $��客户档案修改��6(   $��18(�6f   $��	0,10,10,0q�6t   ��66   �� *
Foreground+$ C��6�   �� 5      $��2��6%   $	��Top=�60   $��0q�6E   $��0,5,0,5q�6�   ��6Y   �� *
Foreground+$ C��6�   ]� 5      $��5q�6(   .+�5   "   �� $��客户姓名*：��6,      	LeftTitle#��[  6:   6_   �� 5    "   -   5        $ InText��5    *    � ToolTip$ 员工姓名(15字以内)��6:     ShortTextBox#��[ 6P   5!      �� 5#      $��5q�6)   $ 
Horizontal=�64   .+�5$   "   �� $��性　　别：��6,   #��[  69   6^   	� 5%   "   -   5         	�Name$
 Sex1��5%   :   $	��男��6.    d� 	IsChecked$
 TrueY�6H   
�������$��Center=�6l   6�   	� 5&   "   -   5        $
 Sex0��5&   :   $	��女��6.   
�������$��Center=�6[   6x   5'      ]� 5*      -	   5        	 ]�Name$	 Address��5*   (   $��5q�69   .+�5+   "   �� $��客户地址：��6,   #��[  69   6^   �� 5,   "   -
   5        $ InAdress��5,   P   #��[ 6*   6d   5-      ]� 5/      $��5q�6(   .+�50   "   �� $��证件类型*：��6,   #��[  6:   6_   �� 51   "   -   5        
 ��Name$
 InPapers��51   +   $��15(�6U   $��2q�6c   $��0q�6�    �� SelectedValuePath$ PapersID��6�    �� DisplayMemberPath$ 
PapersName��6�   ��6=   �� ��6n   Z� ��6�   Z� 6�   52      ]� 54      $��5q�6(   .+�55   "   �� $��证件号码*：��6,   #��[  6:   6_   �� 56   "   -   5        $ InCardID��56   *   $$ 有效二代身份证证件号��6<   #��[ 6Q    �� 	MaxLength$ 30��6w   57      ]� 59      $��5q�6(   .+�5:   "   �� $��手机号码：��6,   #��[  69   6^   �� 5;   "   -   5        $ InTel��5;   *   $( "客户的联系方式(20字以内)��69   #��[ 6R   5<      ]� 5>      -   5        $	 IsVip��5>   3   $��5q�6(   .+�5?   "   �� $��VIP编号：��6,   #��[  6:   6_   �� 5@   "   $��35��6,    �� TextAlignment$ Center=�6:   $��Right=�6Q   $��Center=�6h   �� 5A   &   ��60   �� *
Foreground+$ C��.�6`   添加6d   5B   #   �� 5C   "   -   5        $ InVIPID��5C   *   $> 8客户的VIP号，如果没有则留空（15位以下）��6;   #��[ 6\   5D      �� 5E      $ 
Horizontal=�6)   $��Right=�6B   .+�5F   "      MyControls.OK  -   5        $
��10,5q�5F   B   6R   5G      5H      5I      6!   5J      5K      �� 5N   
   -   5         ��Name$ LB��5N   9   $ VIPID��6E   ��6_   �� ��5O      �� 5P      .R�5Q      � 6"   5R      ��5T      �� 5U      .R�5V      ]� ���#FFFFCC$	��350��65   .+�5W      �� $��10q�6%   .+�5X      �� $ 
Horizontal=�6)   $y�Visible=�6B   .+�5Y   "   �� $��Center=�6,   客户编号：6N   �� 5Z   "   $��Center=�6,    �� Padding$ 2q�6]   ��6G   �� *GUID+6k   5[      �� 5\      $ 
Horizontal=�6)   .+�5]   "   �� $��Center=�6,   	姓名：6L   �� 5^   "   $��Center=�6,   $��18(�6G   $ 2q�6r   ��6U   �� *ClientIName+6�   5_      �� 5`      $ 
Horizontal=�6)   .+�5a   "   �� $��Center=�6,   证件类型：6N   �� 5b   "   $��Center=�6,   $ 2q�6c   ��6G   �� *
PapersName+6q   5c      �� 5d      $ 
Horizontal=�6)   .+�5e   "   �� $��Center=�6,   证件号：6M   �� 5f   "   $��Center=�6,   $ 2q�6e   ��6G   �� *ClientIDCard+6s   5g      �� 5h      $ 
Horizontal=�6)   .+�5i   "   �� $��Center=�6,   	地址：6L   �� 5j   "   $��Center=�6,   $ 2q�6e   ��6G   �� *ClientAdress+6s   5k      �� 5l      $ 
Horizontal=�6)   .+�5m   "   �� $��Center=�6,   VIP编号：6O   �� 5n   "   $��Center=�6,   $ 2q�6d   ��6G   �� *ClientVIPID+6r   5o      �� 5p      $ 
Horizontal=�6)   .+�5q   "   �� $��Center=�6,   联系电话：6N   �� 5r   "   $��Center=�6,   $ 2q�6b   ��6G   �� *	ClientTel+6p   5s      5t      5u      5v      5x      5z      5{      