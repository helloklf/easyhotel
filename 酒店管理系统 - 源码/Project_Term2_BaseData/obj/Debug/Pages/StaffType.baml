   M S B A M L   `   `   `  ����E  AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls  5       Project_Term2_BaseData,   &Project_Term2_BaseData.Pages.StaffType   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;my,clr-namespace:MyControls;assembly=MyControls     5      -   5          � 	Resources  5       �� Source�� 5   
   $ ../Style.xaml?�6   %    66   .��5
      ]� .+�5   
   �� -   5         ��Name$ C��5      $y�	Collapsed=�6   ��64   �� *	ForeColor+��6U   �� *	BgColor+6v      MyControls.DataListMenu  5   
   -   5          Name$ IsCheck��5   /   $	��Top=�6   6�   �� 5   
   $��2��6   $	��Top=�6    J� Opacity$	 0.6Q�61   $
��2,10q�6?   ��6M   �� *
Background+ �� ElementName$ C��6   ]� 5   
   $��Right=�6   .+�5      �� -   5        $��o��5      $��20��6    $��Center=�6.   $	 0.7Q�6P   $��0,0,1,0q�6^   ��6x   �� *
Foreground+$ C��6�   �� 5      $��Disabled=�6   $��Hidden=�6D   .��5      �� -   5        $	��Tab��5   _   $��0q�64   $y�	Collapsed=�6H   $��5q�6�   ��6   Z� ��6j   Z� .@�5      �� $y�	Collapsed=�6   $��0q�6b   ��65   Z� ��6K   Z� .��5      �� .+�5      �� $��新增类型��6(   $��25(�64   $��	0,5,10,10q�6B   ��6U   �� *
Foreground+$ C��6�   ]� 5      $��2q�6(   .+�5   "   �� $��职务类型*：��6,      	LeftTitle#��[  6:   6_   �� 5   "   -   5        $ InText��5   *    � ToolTip$2 ,职务类型(15字以内)，如:前台收银��6:     ShortTextBox#��[ 6W   5      ]� 5      $��2q�6(   .+�5   "   �� $��权限分级*：��6,   #��[  6:   6_   �� 5   "   $��50��6(   $��Right=�66   .��5   &   �� -   5        $��15(�5   0   .�6J   新增6N   5    #   �� 5!   "   -   5         ��Name$ 
InAccredit��5!   +    �� DisplayMemberPath$ 
ALevelName��6?   $��15(�6^   $��2q�6l   $��0q�6�   	 �� SelectedValuePath$	 ALevelID��5"   &   ��5!   w   Z� ��6�   Z� 5"   F   5#         MyControls.OK  5$      -	   5        $��Right=�5$   @   $
��10,5q�6\   6l   5%      5&      �� 5'      $y�	Collapsed=�6   $��0q�6b   ��65   Z� ��6K   Z� .��5(      �� .+�5)      �� $��修改类型��6(   $��25(�64   $��	0,5,10,10q�6B   ��6U   �� *
Foreground+$ C��6�   ]� 5*      $��2q�6(   .+�5+   "   �� $��职务类型*：��6,   #��[  6:   6_   �� 5,   "   -
   5        $ UpText��5,   *   $2 ,职务类型(15字以内)，如:前台收银��6:   #��[ 6W   5-      ]� 5.      $��2q�6(   .+�5/   "   �� $��权限分级*：��6,   #��[  6:   6_   �� 50   "   $��30��6(   $��0q�66   $��Center=�6B   $��Right=�6d   .��51   &   �� -   5        $��12(�51   0   .�6J   添加6N   52   #   �� 53   "   -   5        $ 
UpAccredit��53   +   $ 
ALevelName��6?   $��15(�6^   $��2q�6l   $��0q�6�   $	 ALevelID��54   &   ��53   w   Z� ��6�   Z� 54   F   55      �� 56      
 �� Orientation$
 
Horizontal=�6)   $��Right=�6B   $��5q�6^   .+�57   "      MyControls.No  -   5        57   A     58   "   -   5        $
��10,5q�58   F   6V   59      5:      5;      5<      5=      5>      ]� 5@   
   $��5q�6   $	��Top=�6   .+�5A         MyControls.DataListBox  -   5          Name$ LB��5A         SelectedValuePath$ ALevelID��6)      ItemTemplate 5B      �� 5C      .R�5D      ]� ���#FFFFCC$	��200��69   .+�5E      �� $��10q�6)   .+�5F   "   �� $
 
Horizontal=�6-   $y�Visible=�6F   .+�5G   &   �� $
 
Horizontal=�61   $��Center=�6J   .+�5H   *   �� $��Center=�64   	编号：6T   �� 5I   *   $��Center=�64    �� Padding$ 2q�6h   ��6O   �� *	STypeID+6v   5J   '   �� 5K   &   $��20,0,0,0q�61   $
 
Horizontal=�6C   $��Center=�6\   .+�5L   *   �� $��Center=�64   有效性：6U   �� 5M   *   $��Center=�64   $ 2q�6l   ��6O   �� *IsValidText+6z   5N   '   5O   #   �� 5P   "   $
 
Horizontal=�6-   .+�5Q   &   �� $��Center=�60   职务类型：6R   �� 5R   &   $��Center=�60   $��18(�6K   $ 2q�6t   ��6Y   �� *	STypeName+6�   5S   #   �� 5T   "   $
 
Horizontal=�6-   .+�5U   &   �� $��Center=�60   权限级别：6R   �� 5V   &   $��Center=�60   $
��Wrap=�6K   $ 2q�6{   ��6_   �� *
ALevelName+6�   5W   #   5X      5Y      5Z      5\      5]      5_      5`      