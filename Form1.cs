namespace BinaryTree
{
    public partial class Form1 : Form
    {
        BinaryTreeNode root;
        public Form1()
        {
            InitializeComponent();
            // 綁定 TextChanged 事件
            txtNodeCount.TextChanged += InputChanged;
            txtNodeValues.TextChanged += InputChanged;
        }
        private void InputChanged(object sender, EventArgs e)
        {
            int nodeCount;
            if (!int.TryParse(txtNodeCount.Text, out nodeCount))
            {
                lblErrorMessage.Text = "請輸入有效的節點數量";
                return;
            }
            label_txtNodeValues.Text = $"請再分別輸入這 {nodeCount} 個節點的內容";
            // 分析節點內容
            var nodeValues = txtNodeValues.Text.Split(',');
            if (nodeValues.Length != nodeCount)
            {
                lblErrorMessage.Text = "節點數量與內容不符";
                return;
            }

            // 嘗試將節點內容轉換為數字
            try
            {
                var values = nodeValues.Select(int.Parse).ToArray();
                // 生成二元樹
                root = null;
                foreach (var value in values)
                {
                    root = InsertNode(root, value);
                }

                // 在 Panel 上繪製二元樹
                panelTree.Invalidate(); // 觸發重繪
            }
            catch
            {
                lblErrorMessage.Text = "節點內容必須是數字";
            }
        }
        // 插入節點到二元樹
        private BinaryTreeNode InsertNode(BinaryTreeNode root, int value)
        {
            if (root == null)
            {
                return new BinaryTreeNode(value);
            }

            if (value < root.Value)
            {
                root.Left = InsertNode(root.Left, value);
            }
            else
            {
                root.Right = InsertNode(root.Right, value);
            }

            return root;
        }
        private int GetTreeDepth(BinaryTreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetTreeDepth(node.Left), GetTreeDepth(node.Right));
        }
        private void panelTree_Paint(object sender, PaintEventArgs e)
        {
            if (root == null) return;

            Graphics g = e.Graphics;
            int panelWidth = panelTree.Width;

            // 根據樹的深度動態設置節點之間的距離
            int treeDepth = GetTreeDepth(root);
            int nodeRadius = 20;
            int xSpacing = panelWidth / (int)Math.Pow(2, treeDepth); // 動態設置X間距
            int ySpacing = 50;

            // 從根節點開始繪製
            DrawTree(g, root, panelWidth / 2, 20, xSpacing, ySpacing, nodeRadius);
        }
        private void DrawTree(Graphics g, BinaryTreeNode node, int x, int y, int xSpacing, int ySpacing, int nodeRadius)
        {
            if (node == null) return;

            // 繪製當前節點
            DrawNode(g, node, x, y, nodeRadius);

            // 繪製左子樹
            if (node.Left != null)
            {
                // 計算左子樹的座標
                int childX = x - xSpacing;
                int childY = y + ySpacing;
                // 繪製連接線
                g.DrawLine(Pens.White, x, y, childX, childY);
                // 繼續繪製左子樹
                DrawTree(g, node.Left, childX, childY, xSpacing / 2, ySpacing, nodeRadius);
            }

            // 繪製右子樹
            if (node.Right != null)
            {
                // 計算右子樹的座標
                int childX = x + xSpacing;
                int childY = y + ySpacing;

                // 繪製連接線
                g.DrawLine(Pens.Black, x, y, childX, childY);

                // 繼續繪製右子樹
                DrawTree(g, node.Right, childX, childY, xSpacing / 2, ySpacing, nodeRadius);
            }
        }
        // 繪製節點的圓形與數值
        private void DrawNode(Graphics g, BinaryTreeNode node, int x, int y, int radius)
        {
            // 繪製節點圓形
            g.FillEllipse(Brushes.White, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(Pens.Black, x - radius, y - radius, radius * 2, radius * 2);

            // 繪製節點值
            var font = new Font("Arial", 12);
            var stringSize = g.MeasureString(node.Value.ToString(), font);
            g.DrawString(node.Value.ToString(), font, Brushes.Black, x - stringSize.Width / 2, y - stringSize.Height / 2);
        }
        // 按鈕事件：將二元樹轉換成一維陣列並顯示
        private void btnConvertToArray_Click(object sender, EventArgs e)
        {
            if (root == null)
            {
                lblErrorMessage.Text = "二元樹為空";
                return;
            }

            // 選擇遍歷方式
            var resultList = new List<int>();
            InOrderTraversal(root, resultList); // 中序遍歷

            // 將結果顯示在 Label 上
            lblArrayResult.Text = "一維陣列: " + string.Join(", ", resultList);
        }

        // 中序遍歷
        private void InOrderTraversal(BinaryTreeNode node, List<int> result)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }
    }
}
