namespace SWSv2
{
    partial class FormDataGridView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleList = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SuspendLayout();
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
            this.dataGridView1.TabIndex = 3;
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
            this.titleList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.titleList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.genre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.studio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.transfer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // voiceActing
            // 
            this.voiceActing.HeaderText = "Озвучка";
            this.voiceActing.Name = "voiceActing";
            this.voiceActing.ReadOnly = true;
            this.voiceActing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.license.HeaderText = "Лицензия";
            this.license.Name = "license";
            this.license.ReadOnly = true;
            // 
            // FormDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDataGridView";
            this.Text = "FormDataGridView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn vote;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleList;
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