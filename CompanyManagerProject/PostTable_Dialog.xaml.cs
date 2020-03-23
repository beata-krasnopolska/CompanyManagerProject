using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CompanyManager.DAL.Entities;
using CompanyManager.DAL.Repository;


namespace CompanyManagerProject
{
    /// <summary>
    /// Interaction logic for PostTable_Dialog.xaml
    /// </summary>
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

            if (post!= null)
            {
                PostNameTxt.Text = post.Name;
            }
        }

        private void InitializePostListBox()
        {
            PostsListBox.ItemsSource = _postService.GetPosts();
        }

        private void BtnAddPost_Click(object sender, RoutedEventArgs e)
        {
            var post = new Post()
            {
                Name = PostNameTxt.Text,
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
            var post = PostsListBox.SelectedItem as Post;
            if(post == null)
            {
                MessageBox.Show("Post must be selected before update!");
            }

            if(post!= null)
            {
                post.Name = PostNameTxt.Text;
            }

            try
            {
                _postService.UpdatePost(post);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            InitializePostListBox();
        }

        private void BtnDeletePost_Click(object sender, RoutedEventArgs e)
        {
            var post = PostsListBox.SelectedItem as Post;

            if (post == null)
            {
                MessageBox.Show("Post must be selected before delete!");
                return;
            }

            if (post != null)
            {
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
}
