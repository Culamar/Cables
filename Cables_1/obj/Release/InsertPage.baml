   M S B A M L   `   `   `  ���� C  ?Cables_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Cables_1Cables_1      Cables_1.InsertPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:Cables_1       N� Title$  
InsertPage��.��� $	��750��$	��400��.+��� $
��Left=�$��	33,45,0,0q�$
��Wrap=�$1��+Количество жил в кабеле��$	��Top=�$	��162���� -    ��Name$ cores�� �� SelectedIndex$ 0��$
��Left=�$��
272,45,0,0q�$	��Top=�$��39��@��� .��1�� .��3�� -   $ cross_sectional_area��$ 0��$
��Left=�$��23��$��
191,82,0,0q�$	��Top=�$	��120��@��� .��150�� .��185�� .��240�� .��300�� .��400�� .��500�� .��630�� .��800�� .��1000�� -   $! cross_sectional_screen_area��$
��Left=�$��23��$��191,110,0,0q�$ 0��$	��Top=�$	��120��@��� .��95�� .��120�� .��150�� .��185�� $#��Сечение жилы, мм��$
��Left=�$��	33,82,0,0q�$	��Top=��� $'��!Сечение экрана, мм��$
��Left=�$��
33,110,0,0q�$	��Top=��� $��Материал жилы��$
��Left=�$��
33,141,0,0q�$	��Top=��� -   $ material��$ 0��$
��Left=�$��191,141,0,0q�$	��Top=�$	��120��@��� .��Алюминий�� .��
Медь�� -   $ paving��$ 0��$
��Left=�$��191,172,0,0q�$	��Top=�$	��120��@��� .��В плоскости�� .��Треугольником�� $
��Left=�$��
33,172,0,0q�$
��Wrap=�$'��!Способ прокладлки��$	��Top=�$	��128���� -   $ environment��$ 0��$
��Left=�$��191,203,0,0q�$	��Top=�$	��120��@��� .��
Земля�� .��Воздух�� $
��Left=�$��
33,231,0,0q�$
��Wrap=�$c��]Удельное сопротивление жилы постоянному току, Ом/м��$	��Top=�$	��143���� -    ��Name$ 
resistance��$
��Left=�$��23��$��191,240,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120�� �� 	MaxLength$ 10���� $
��Left=�$��
33,203,0,0q�$
��Wrap=�$%��Среда прокладлки��$	��Top=�$	��128���� $
��Left=�$��
33,284,0,0q�$
��Wrap=�$8��2Наружный диаметр кабеля, мм��$	��Top=�$	��143���� -   $ diameter��$
��Left=�$��23��$��191,283,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$ 10���� $
��Left=�$��
33,322,0,0q�$
��Wrap=�$#��Диаметр жилы, мм��$	��Top=�$	��153���� -	   $ core_diameter��$
��Left=�$��23��$��191,321,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$ 10���� $
��Left=�$��
410,83,0,0q�$
��Wrap=�$F��@Глубина заложения кабеля в грунт, м��$	��Top=�$	��153���� $
��Left=�$��
410,45,0,0q�$
��Wrap=�$��Напряжение��$	��Top=�$	��153���� -
   $ U��$ 0��$
��Left=�$��
568,45,0,0q�$	��Top=�$	��120��.@��� $��6 кВ���� $��10 кВ���� $��20 кВ���� $��35 кВ���� $��110 кВ���� -   $ La��$
��Left=�$��23��$��
568,85,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$ 10���� $
��Left=�$��410,128,0,0q�$
��Wrap=�$K��EУдельное сопротивление грунта, К·м/Вт��$	��Top=�$	��153���� -   $
 rogr��$
��Left=�$��23��$��568,127,0,0q�$
 Wrap=�$	��1.8��$	��Top=�$	��120��$ 10���� $
��Left=�$��410,172,0,0q�$
��Wrap=�$'��!Материал оболочки��$	��Top=�$	��153���� -   $ 	obolochka��$ 0��$
��Left=�$��568,172,0,0q�$	��Top=�$	��120��.@��� $��Полиэтилен���� $$��Поливинилхлорид���� $
��Left=�$��410,213,0,0q�$
��Wrap=�$��
Броня��$	��Top=�$	��153���� -   $ Armor��$ 0��$
��Left=�$��568,213,0,0q�$	��Top=�$	��120��.@��� $7��1Алюмининиевая проволочная���� $)��#Стальная ленточная���� $-��'Стальная проволочная���� $��Без брони���� $
��Left=�$��
137,82,0,0q�$
��Wrap=�$��2��$	��Top=�$��8(��� -   $��Расчёт��$
��Left=�$��376,322,0,0q�$	��Top=�$	��166��$��50���� -    ��Name$ Cansel��$��
Назад��$
��Left=�$��568,322,0,0q�$	��Top=�$	��166��$��50���� $
��Left=�$��150,113,0,0q�$
��Wrap=�$��2��$	��Top=�$��8(�