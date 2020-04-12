namespace SWSv2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleList = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.released = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.season = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primarySourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voiceActing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.license = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(713, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scrape";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.rating,
            this.vote,
            this.titleList,
            this.view,
            this.status,
            this.released,
            this.season,
            this.ageRating,
            this.genre,
            this.primarySourse,
            this.studio,
            this.producer,
            this.type,
            this.series,
            this.transfer,
            this.voiceActing,
            this.description,
            this.urlImage,
            this.license});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 2;
            // 
            // title
            // 
            this.title.HeaderText = "Название";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // rating
            // 
            this.rating.HeaderText = "Рейтинг";
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            // 
            // vote
            // 
            this.vote.HeaderText = "Количество голосов";
            this.vote.Name = "vote";
            this.vote.ReadOnly = true;
            // 
            // titleList
            // 
            this.titleList.HeaderText = "Альтернативные названия";
            this.titleList.Name = "titleList";
            this.titleList.ReadOnly = true;
            // 
            // view
            // 
            this.view.HeaderText = "Просмотры";
            this.view.Name = "view";
            this.view.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // released
            // 
            this.released.HeaderText = "Дата выхода";
            this.released.Name = "released";
            this.released.ReadOnly = true;
            // 
            // season
            // 
            this.season.HeaderText = "Сезон";
            this.season.Name = "season";
            this.season.ReadOnly = true;
            // 
            // ageRating
            // 
            this.ageRating.HeaderText = "Возростной рейтинг";
            this.ageRating.Name = "ageRating";
            this.ageRating.ReadOnly = true;
            // 
            // genre
            // 
            this.genre.HeaderText = "Жанр";
            this.genre.Name = "genre";
            this.genre.ReadOnly = true;
            // 
            // primarySourse
            // 
            this.primarySourse.HeaderText = "Первоисточник";
            this.primarySourse.Name = "primarySourse";
            this.primarySourse.ReadOnly = true;
            // 
            // studio
            // 
            this.studio.HeaderText = "Студия";
            this.studio.Name = "studio";
            this.studio.ReadOnly = true;
            // 
            // producer
            // 
            this.producer.HeaderText = "Режиссер";
            this.producer.Name = "producer";
            this.producer.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // series
            // 
            this.series.HeaderText = "Серии";
            this.series.Name = "series";
            this.series.ReadOnly = true;
            // 
            // transfer
            // 
            this.transfer.HeaderText = "Перевод";
            this.transfer.Name = "transfer";
            this.transfer.ReadOnly = true;
            // 
            // voiceActing
            // 
            this.voiceActing.HeaderText = "Озвучка";
            this.voiceActing.Name = "voiceActing";
            this.voiceActing.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Описание";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // urlImage
            // 
            this.urlImage.HeaderText = "Постер";
            this.urlImage.Name = "urlImage";
            this.urlImage.ReadOnly = true;
            // 
            // license
            // 
            this.license.HeaderText = "Лиценция";
            this.license.Name = "license";
            this.license.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Simple Web Scraper v2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn vote;
        private System.Windows.Forms.DataGridViewComboBoxColumn titleList;
        private System.Windows.Forms.DataGridViewTextBoxColumn view;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn released;
        private System.Windows.Forms.DataGridViewTextBoxColumn season;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn primarySourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn studio;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn series;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn voiceActing;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn license;
    }
}

