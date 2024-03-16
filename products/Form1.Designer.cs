namespace products
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            filterSelect = new ComboBox();
            sortFieldSelect = new ComboBox();
            searchInput = new TextBox();
            productsDataGridView = new DataGridView();
            sortDirectionSelect = new ComboBox();
            label4 = new Label();
            prevPageBtn = new Button();
            nextPageBtn = new Button();
            id = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            producttypeid = new DataGridViewTextBoxColumn();
            article = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            image = new DataGridViewTextBoxColumn();
            productionpersoncount = new DataGridViewTextBoxColumn();
            productionworkshopnumber = new DataGridViewTextBoxColumn();
            mincostforagent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Строка поиска";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(174, 18);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Фильтрация";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 18);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 2;
            label3.Text = "Сортировка";
            // 
            // filterSelect
            // 
            filterSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            filterSelect.FormattingEnabled = true;
            filterSelect.Items.AddRange(new object[] { "Все типы" });
            filterSelect.Location = new Point(174, 41);
            filterSelect.Name = "filterSelect";
            filterSelect.Size = new Size(151, 28);
            filterSelect.TabIndex = 3;
            filterSelect.SelectedValueChanged += filterSelect_SelectedValueChanged;
            // 
            // sortFieldSelect
            // 
            sortFieldSelect.AutoCompleteMode = AutoCompleteMode.Append;
            sortFieldSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            sortFieldSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            sortFieldSelect.FormattingEnabled = true;
            sortFieldSelect.Items.AddRange(new object[] { "наименование", "номер цеха", "минимальная цена для агента" });
            sortFieldSelect.Location = new Point(331, 41);
            sortFieldSelect.Name = "sortFieldSelect";
            sortFieldSelect.Size = new Size(228, 28);
            sortFieldSelect.TabIndex = 4;
            sortFieldSelect.SelectedValueChanged += sortSelect_SelectedValueChanged;
            // 
            // searchInput
            // 
            searchInput.Location = new Point(12, 42);
            searchInput.Name = "searchInput";
            searchInput.Size = new Size(156, 27);
            searchInput.TabIndex = 5;
            searchInput.TextChanged += searchInput_TextChanged;
            // 
            // productsDataGridView
            // 
            productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsDataGridView.Columns.AddRange(new DataGridViewColumn[] { id, title, producttypeid, article, description, image, productionpersoncount, productionworkshopnumber, mincostforagent });
            productsDataGridView.Location = new Point(12, 75);
            productsDataGridView.Name = "productsDataGridView";
            productsDataGridView.RowHeadersWidth = 51;
            productsDataGridView.Size = new Size(1180, 363);
            productsDataGridView.TabIndex = 6;
            // 
            // sortDirectionSelect
            // 
            sortDirectionSelect.AutoCompleteMode = AutoCompleteMode.Append;
            sortDirectionSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            sortDirectionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            sortDirectionSelect.FormattingEnabled = true;
            sortDirectionSelect.Items.AddRange(new object[] { "По возрастанию", "По убыванию" });
            sortDirectionSelect.Location = new Point(565, 41);
            sortDirectionSelect.Name = "sortDirectionSelect";
            sortDirectionSelect.Size = new Size(228, 28);
            sortDirectionSelect.TabIndex = 8;
            sortDirectionSelect.SelectedValueChanged += sortDirectionSelect_SelectedValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(565, 18);
            label4.Name = "label4";
            label4.Size = new Size(190, 20);
            label4.TabIndex = 9;
            label4.Text = "Направление сортировки";
            // 
            // prevPageBtn
            // 
            prevPageBtn.Location = new Point(12, 444);
            prevPageBtn.Name = "prevPageBtn";
            prevPageBtn.Size = new Size(30, 30);
            prevPageBtn.TabIndex = 10;
            prevPageBtn.Text = "<";
            prevPageBtn.UseVisualStyleBackColor = true;
            prevPageBtn.Click += prevPageBtn_Click;
            // 
            // nextPageBtn
            // 
            nextPageBtn.Location = new Point(48, 444);
            nextPageBtn.Name = "nextPageBtn";
            nextPageBtn.Size = new Size(30, 30);
            nextPageBtn.TabIndex = 11;
            nextPageBtn.Text = ">";
            nextPageBtn.UseVisualStyleBackColor = true;
            nextPageBtn.Click += nextPageBtn_Click;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.SortMode = DataGridViewColumnSortMode.NotSortable;
            id.Width = 125;
            // 
            // title
            // 
            title.HeaderText = "Наименование";
            title.MinimumWidth = 6;
            title.Name = "title";
            title.Width = 125;
            // 
            // producttypeid
            // 
            producttypeid.HeaderText = "id типа";
            producttypeid.MinimumWidth = 6;
            producttypeid.Name = "producttypeid";
            producttypeid.Width = 125;
            // 
            // article
            // 
            article.HeaderText = "Артикул";
            article.MinimumWidth = 6;
            article.Name = "article";
            article.Width = 125;
            // 
            // description
            // 
            description.HeaderText = "Описание";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Width = 125;
            // 
            // image
            // 
            image.HeaderText = "Фото";
            image.MinimumWidth = 6;
            image.Name = "image";
            image.Width = 125;
            // 
            // productionpersoncount
            // 
            productionpersoncount.HeaderText = "Количество человек для производства";
            productionpersoncount.MinimumWidth = 6;
            productionpersoncount.Name = "productionpersoncount";
            productionpersoncount.Width = 125;
            // 
            // productionworkshopnumber
            // 
            productionworkshopnumber.HeaderText = "Номер цеха";
            productionworkshopnumber.MinimumWidth = 6;
            productionworkshopnumber.Name = "productionworkshopnumber";
            productionworkshopnumber.Width = 125;
            // 
            // mincostforagent
            // 
            mincostforagent.HeaderText = "Минимальная цена для агента";
            mincostforagent.MinimumWidth = 6;
            mincostforagent.Name = "mincostforagent";
            mincostforagent.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 487);
            Controls.Add(nextPageBtn);
            Controls.Add(prevPageBtn);
            Controls.Add(label4);
            Controls.Add(sortDirectionSelect);
            Controls.Add(productsDataGridView);
            Controls.Add(searchInput);
            Controls.Add(sortFieldSelect);
            Controls.Add(filterSelect);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox filterSelect;
        private ComboBox sortFieldSelect;
        private TextBox searchInput;
        private DataGridView productsDataGridView;
        private ComboBox sortDirectionSelect;
        private Label label4;
        private Button prevPageBtn;
        private Button nextPageBtn;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn producttypeid;
        private DataGridViewTextBoxColumn article;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn image;
        private DataGridViewTextBoxColumn productionpersoncount;
        private DataGridViewTextBoxColumn productionworkshopnumber;
        private DataGridViewTextBoxColumn mincostforagent;
    }
}
