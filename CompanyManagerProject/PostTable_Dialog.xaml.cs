using CompanyManager.DAL.Entities;
using CompanyManager.DAL.Repository;
using System;
using System.Windows;
using System.Windows.Controls;


namespace CompanyManagerProject
{
    public partial class PostTable_Dialog : Window
    {
        private readonly PostService _postService = new PostService();

        public PostTable_Dialog()
        {
            InitializeComponent();

            InitializePostListBox();
        }

        private void PostsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(PostsListBox.SelectedItem is Post post))
            {
                return;
            }
            
            PostNameTxt.Text = post.Name;            
        }

        private void InitializePostListBox()
        {
            PostsListBox.ItemsSource = _postService.GetPosts();
        }

        private void BtnAddPost_Click(object sender, RoutedEventArgs e)
        {
            if (PostNameTxt.Text.Length < 2)
            {
                MessageBox.Show(Messages.PostNameError);
                return;
            }

            var post = new Post
            {
                Name = PostNameTxt.Text
            };

            try
            {
                _postService.InsertPost(post);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializePostListBox();
        }

        private void BtnUpdatePost_Click(object sender, RoutedEventArgs e)
        {
            if (!(PostsListBox.SelectedItem is Post post))
            {
                MessageBox.Show(Messages.PostUpdateError);
                return;
            }

            post.Name = PostNameTxt.Text;

            try
            {
                _postService.UpdatePost(post);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializePostListBox();
        }

        private void BtnDeletePost_Click(object sender, RoutedEventArgs e)
        {

            if (!(PostsListBox.SelectedItem is Post post))
            {
                MessageBox.Show(Messages.PostDeleteError);
                return;
            }

            try
            {
                _postService.DeletePost(post.Id);
                PostNameTxt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializePostListBox();            
        }
    }
}
