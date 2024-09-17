namespace BinaryTree
{
    public partial class Form1 : Form
    {
        BinaryTreeNode root;
        public Form1()
        {
            InitializeComponent();
            // �j�w TextChanged �ƥ�
            txtNodeCount.TextChanged += InputChanged;
            txtNodeValues.TextChanged += InputChanged;
        }
        private void InputChanged(object sender, EventArgs e)
        {
            int nodeCount;
            if (!int.TryParse(txtNodeCount.Text, out nodeCount))
            {
                lblErrorMessage.Text = "�п�J���Ī��`�I�ƶq";
                return;
            }
            label_txtNodeValues.Text = $"�ЦA���O��J�o {nodeCount} �Ӹ`�I�����e";
            // ���R�`�I���e
            var nodeValues = txtNodeValues.Text.Split(',');
            if (nodeValues.Length != nodeCount)
            {
                lblErrorMessage.Text = "�`�I�ƶq�P���e����";
                return;
            }

            // ���ձN�`�I���e�ഫ���Ʀr
            try
            {
                var values = nodeValues.Select(int.Parse).ToArray();
                // �ͦ��G����
                root = null;
                foreach (var value in values)
                {
                    root = InsertNode(root, value);
                }

                // �b Panel �Wø�s�G����
                panelTree.Invalidate(); // Ĳ�o��ø
            }
            catch
            {
                lblErrorMessage.Text = "�`�I���e�����O�Ʀr";
            }
        }
        // ���J�`�I��G����
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

            // �ھھ𪺲`�װʺA�]�m�`�I�������Z��
            int treeDepth = GetTreeDepth(root);
            int nodeRadius = 20;
            int xSpacing = panelWidth / (int)Math.Pow(2, treeDepth); // �ʺA�]�mX���Z
            int ySpacing = 50;

            // �q�ڸ`�I�}�lø�s
            DrawTree(g, root, panelWidth / 2, 20, xSpacing, ySpacing, nodeRadius);
        }
        private void DrawTree(Graphics g, BinaryTreeNode node, int x, int y, int xSpacing, int ySpacing, int nodeRadius)
        {
            if (node == null) return;

            // ø�s��e�`�I
            DrawNode(g, node, x, y, nodeRadius);

            // ø�s���l��
            if (node.Left != null)
            {
                // �p�⥪�l�𪺮y��
                int childX = x - xSpacing;
                int childY = y + ySpacing;
                // ø�s�s���u
                g.DrawLine(Pens.White, x, y, childX, childY);
                // �~��ø�s���l��
                DrawTree(g, node.Left, childX, childY, xSpacing / 2, ySpacing, nodeRadius);
            }

            // ø�s�k�l��
            if (node.Right != null)
            {
                // �p��k�l�𪺮y��
                int childX = x + xSpacing;
                int childY = y + ySpacing;

                // ø�s�s���u
                g.DrawLine(Pens.Black, x, y, childX, childY);

                // �~��ø�s�k�l��
                DrawTree(g, node.Right, childX, childY, xSpacing / 2, ySpacing, nodeRadius);
            }
        }
        // ø�s�`�I����λP�ƭ�
        private void DrawNode(Graphics g, BinaryTreeNode node, int x, int y, int radius)
        {
            // ø�s�`�I���
            g.FillEllipse(Brushes.White, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(Pens.Black, x - radius, y - radius, radius * 2, radius * 2);

            // ø�s�`�I��
            var font = new Font("Arial", 12);
            var stringSize = g.MeasureString(node.Value.ToString(), font);
            g.DrawString(node.Value.ToString(), font, Brushes.Black, x - stringSize.Width / 2, y - stringSize.Height / 2);
        }
        // ���s�ƥ�G�N�G�����ഫ���@���}�C�����
        private void btnConvertToArray_Click(object sender, EventArgs e)
        {
            if (root == null)
            {
                lblErrorMessage.Text = "�G���𬰪�";
                return;
            }

            // ��ܹM���覡
            var resultList = new List<int>();
            InOrderTraversal(root, resultList); // ���ǹM��

            // �N���G��ܦb Label �W
            lblArrayResult.Text = "�@���}�C: " + string.Join(", ", resultList);
        }

        // ���ǹM��
        private void InOrderTraversal(BinaryTreeNode node, List<int> result)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }
    }
}
