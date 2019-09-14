using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    //九宫格固定位置，逐行遍历
    public Transform[] gridCenterPos = new Transform[blockAmount];
    //拼图方块
    public GameObject[] blocks = new GameObject[blockAmount-2];
    [HideInInspector]
    public bool isFinish = false;
    public GameObject chaosPuzzle;
    public GameObject boardAll;
    //public Sprite notched;

    public static PuzzleController instance = null;

    private const int blockAmount = 9;
    private const int blockAmountPerRow = blockAmount / 3;
    //private const float distanceUnitLength = 0.5f;
    private const float frameCount = 10;
    //private bool moveable = true;
    private int count = 0;
    private float transitionTime = 0.5f;
    class Point
    {
        public int row;
        public int col;
        public Point(int row,int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    private int[,] goalMap = new int[blockAmountPerRow, blockAmountPerRow] {
        { 0,1,-1 },
        { 2,3,-1 },
        { 4,5,6}
    };

    //private Point emptyPos1;//0-8
    private List<Point> emptyPoints=new List<Point>();//0-8
    private int[,] beginMap = new int[blockAmountPerRow, blockAmountPerRow]
    {
        { 6,3,5 },
        { 0,2,-1 },
        { 1,4,-1}
    };

    private int[,] currentMap = new int[blockAmountPerRow, blockAmountPerRow] {
        { 6,3,5 },
        { 0,2,-1 },
        { 1,4,-1}
    };
    //private int[,] currentMap = new int[blockAmountPerRow, blockAmountPerRow]
    //{
    //    { 0,1,4 },
    //    { 2,3,7 },
    //    { 5,6,-1}
    //};
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ResetPuzzle();
    }

    public void ResetPuzzle()
    {
        emptyPoints.Clear();
        for(int i = 0; i < blockAmountPerRow; i++)
        {
            for(int j=0;j< blockAmountPerRow; j++)
            {
                currentMap[i,j] = beginMap[i,j];
            }
        }
        //初始化
        for (int row = 0; row < blockAmountPerRow; row++)
        {
            for (int col = 0; col < blockAmountPerRow; col++)
            {
                if (currentMap[row, col] != -1)
                {
                    blocks[currentMap[row, col]].transform.localPosition = gridCenterPos[row * blockAmountPerRow + col].localPosition;
                }
                else
                {
                    //emptyPos[0] = new Point(row, col);
                    emptyPoints.Add(new Point(row, col));
                }
            }
        }
    }
    private void OnEnable()
    {
        if (CharacterController.instance != null)
        {
            CharacterController.instance.moveable = false;
        }
    }

    private void OnDisable()
    {
        if (CharacterController.instance != null)
        {
            CharacterController.instance.moveable = true;
        }
    }

    void FixedUpdate()
    {
        if (count==0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
                UpdateEmptyPoints();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
                UpdateEmptyPoints();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
                UpdateEmptyPoints();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
                UpdateEmptyPoints();
            }
        }
    }

    //交换值
    private void Swap(ref int x,ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    private void UpdateEmptyPoints()
    {
        emptyPoints.Clear();
        for(int row = 0; row < blockAmountPerRow; row++)
        {
            for (int col = 0; col < blockAmountPerRow; col++)
            {
                if (currentMap[row, col] == -1)
                {
                    emptyPoints.Add(new Point(row, col));
                }
            }
        }
    }
    //向上移动
    private void MoveUp()
    {
        //总是两个emptyPoint
        if (emptyPoints[0].col != emptyPoints[1].col)
        {
            foreach(Point point in emptyPoints)
            {
                MoveUp(point);
            }

        }
        else
        {
            MoveUp(emptyPoints[0]);
        }
        JudgSuccess();
    }

    private void MoveUp(Point emptyPoint)
    {
        int col = emptyPoint.col;
        int row = emptyPoint.row;
        for(int i=row;i< blockAmountPerRow-1; i++)
        {
            if (currentMap[i + 1, col] != -1)
            {
                ToDest(blocks[currentMap[i + 1, col]], i, col);
                Swap(ref currentMap[i, col], ref currentMap[i + 1, col]);
            }

        }
        //emptyPoint.row = blockAmountPerRow-1;
    }

    //向下移动
    private void MoveDown()
    {       
        //总是两个emptyPoint
        if (emptyPoints[0].col != emptyPoints[1].col)
        {
            foreach (Point point in emptyPoints)
            {
                MoveDown(point);
            }

        }
        else
        {
            MoveDown(emptyPoints[1]);
        }
        JudgSuccess();

    }

    private void MoveDown(Point emptyPoint)
    {
        int col = emptyPoint.col;
        int row = emptyPoint.row;
        for (int i = row; i >0; i--)
        {
            if (currentMap[i - 1, col] != -1)
            {
                ToDest(blocks[currentMap[i - 1, col]], i, col);
                Swap(ref currentMap[i, col], ref currentMap[i - 1, col]);
            }
        }
        //emptyPoint.row = 0;
    }

    //向左移动
    private void MoveLeft()
    {
        if (emptyPoints[0].row != emptyPoints[1].row)
        {
            foreach (Point point in emptyPoints)
            {
                MoveLeft(point);
            }

        }
        else
        {
            MoveLeft(emptyPoints[0]);
        }
        JudgSuccess();

    }

    private void MoveLeft(Point emptyPoint)
    {
        int row = emptyPoint.row;
        int col = emptyPoint.col;
        for (int i = col; i < blockAmountPerRow - 1; i++)
        {
            if (currentMap[row, i + 1] != -1)
            {
                ToDest(blocks[currentMap[row, i + 1]], row, i);
                Swap(ref currentMap[row, i], ref currentMap[row, i + 1]);
            }

        }
        //emptyPoint.col = blockAmountPerRow - 1;
    }

    //向右移动
    private void MoveRight()
    {
        if (emptyPoints[0].row != emptyPoints[1].row)
        {
            foreach (Point point in emptyPoints)
            {
                MoveRight(point);
            }

        }
        else
        {
            MoveRight(emptyPoints[1]);
        }
        JudgSuccess();

    }

    private void MoveRight(Point emptyPoint)
    {
        int row = emptyPoint.row;
        int col = emptyPoint.col;
        for (int i = col; i >0; i--)
        {
            if (currentMap[row, i - 1] != -1)
            {
                ToDest(blocks[currentMap[row, i - 1]], row, i);
                Swap(ref currentMap[row, i], ref currentMap[row, i - 1]);
            }
        }
        //emptyPoint.col = 0;
    }

    //destinationX，destinationY均在0-2之间
    private void ToDest(GameObject block,int destinationRow,int destinationCol)
    {
        count++;
        StartCoroutine(TranslateAnim(block, gridCenterPos[destinationRow * blockAmountPerRow + destinationCol]));
    }

    IEnumerator TranslateAnim(GameObject block,Transform trans)
    {
        Vector3 deltaVector = trans.localPosition - block.transform.localPosition;
        Vector3 everyFrameDelta = deltaVector / frameCount;
        yield return new WaitForEndOfFrame();
        for(int i = 0; i < frameCount; i++)
        {
            yield return new WaitForSeconds(transitionTime/frameCount);
            block.transform.localPosition += everyFrameDelta;
        }
        count--;
    }

    //判断是否通关
    bool IsCorrect()
    {
        for(int row = 0; row < blockAmountPerRow; row++)
        {
            for(int col = 0; col < blockAmountPerRow; col++)
            {
                if (goalMap[row, col] != currentMap[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    void JudgSuccess()
    {
        if (IsCorrect())
        {
            isFinish = true;
            TipsManager.instance.FlyIn("您已完成拼图");
            //chaosPuzzle.GetComponent<SpriteRenderer>().sprite = notched;
            StartCoroutine(DestroyPuzzle());
            Debug.Log("您已完成拼图");
        }
    }

    IEnumerator DestroyPuzzle()
    {
        yield return new WaitForSeconds(1);//等拼图动画结束
        if (boardAll != null && chaosPuzzle != null)
        {
            DestroyImmediate(boardAll);
            Destroy(chaosPuzzle);
            if (BackPackManager.instance != null)
            {
                BackPackManager.instance.AddProp("残缺画");
            }
        }
    }
}
