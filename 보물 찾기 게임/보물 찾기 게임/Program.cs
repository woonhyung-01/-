using System;
using System.Threading;

Console.WriteLine("보물 찾기 게임");
Thread.Sleep(500);
Console.Clear();
Console.WriteLine("....보물 숨기는 중......");
Thread.Sleep(1000);
Console.Clear();

Random random = new Random();
int shufle = random.Next(1, 13);

char[] box = new char[12];

for (int i = 0; i < box.Length; i++)
{
    box[i] = '·';
}

char player = 'X';

const int maxKey = 8;
int key = 0;


Console.WriteLine("===보물 찾기 게임===");
Console.WriteLine("1부터 12까지의 상자 중 선택하세요.");

while (true)
{
    PrintBoard();
    Console.WriteLine("보물을 찾아주세요!");
    int position = GetValidPosition(box);
    int index = position - 1;
    box[index] = player;
    key++;
    if (Finish(box, player))
    {
        box[index] = 'O';
        PrintBoard();
        Console.WriteLine("보물을 발견하셨습니다!");
        Console.WriteLine("!!!성공!!!");
        break;
    }
    if (maxKey == key)
    {
        int transitional = shufle - 1;
        box[transitional] = 'O';
        PrintBoard();
        Console.WriteLine("보물을 찾지 못했습니다.");
        Console.WriteLine("실패! ㅠㅠ");
        break;
    }
}

void PrintBoard()
{
    Console.Clear();
    Console.WriteLine("===보물 찾기 게임===");
    Console.WriteLine("1부터 12까지의 상자 중 선택하세요.");
    Console.WriteLine();
    for (int j = 1; j <= box.Length; j++)
    {
        Console.Write($" {j,2} ");
        if (j % 4 == 0)
        {
            Console.WriteLine();
            if (j < 9)
            {
                Console.WriteLine("----+----+----+----");
            }
        }
        else
        {
            Console.Write("|");
        }
    }
    Console.WriteLine();

    for (int i = 0; i < box.Length; i++)
    {
        Console.Write($" {box[i],2} ");
        if (i % 4 == 3)
        {
            Console.WriteLine();
            if (i < 8)
            {
                Console.WriteLine("----+----+----+----");
            }
        }
        else
        {
            Console.Write("|");
        }
    }
    Console.WriteLine();
}

int GetValidPosition(char[] box)
{
    while (true)
    {
        Console.Write("상자의 번호를 입력하세요.: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int position))
        {
            Console.WriteLine("숫자를 입력하세요.");
            continue;
        }
        if (position < 1 || position > 12)
        {
            Console.WriteLine("범위 안의 숫자를 입력하세요. (1 ~ 12)");
            continue;
        }
        int index = position - 1;
        if (box[index] != '·')
        {
            Console.WriteLine("이미 선택된 칸입니다. 다른 번호를 입력해 주세요.");
            continue;
        }

        return position;
    }
}

bool Finish(char[] box, char player)
{
    if (CheckBox(box, player, shufle)) return true;
    return false;
}

bool CheckBox(char[] box, char player, int x)
{
    return box[x - 1] == player;
}