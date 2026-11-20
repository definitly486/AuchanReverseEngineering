.class Lcom/zerobranch/layout/SwipeLayout$4;
.super Ljava/lang/Object;
.source "SwipeLayout.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/zerobranch/layout/SwipeLayout;->setupPost()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/zerobranch/layout/SwipeLayout;


# direct methods
.method constructor <init>(Lcom/zerobranch/layout/SwipeLayout;)V
    .locals 0

    .line 907
    iput-object p1, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .line 910
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 911
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$600(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v0

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v1}, Lcom/zerobranch/layout/SwipeLayout;->access$800(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v1

    int-to-float v1, v1

    invoke-virtual {v0, v1}, Landroid/view/View;->setX(F)V

    return-void

    .line 912
    :cond_0
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v0

    const/4 v1, 0x2

    if-ne v0, v1, :cond_1

    .line 913
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v0

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v1}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v1

    invoke-virtual {v1}, Landroid/view/View;->getWidth()I

    move-result v1

    neg-int v1, v1

    int-to-float v1, v1

    invoke-virtual {v0, v1}, Landroid/view/View;->setX(F)V

    return-void

    .line 914
    :cond_1
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$500(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v0

    const/4 v1, 0x3

    if-ne v0, v1, :cond_2

    .line 915
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$600(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v0

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v1}, Lcom/zerobranch/layout/SwipeLayout;->access$800(Lcom/zerobranch/layout/SwipeLayout;)I

    move-result v1

    int-to-float v1, v1

    invoke-virtual {v0, v1}, Landroid/view/View;->setX(F)V

    .line 916
    iget-object v0, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v0}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v0

    iget-object v1, p0, Lcom/zerobranch/layout/SwipeLayout$4;->this$0:Lcom/zerobranch/layout/SwipeLayout;

    invoke-static {v1}, Lcom/zerobranch/layout/SwipeLayout;->access$700(Lcom/zerobranch/layout/SwipeLayout;)Landroid/view/View;

    move-result-object v1

    invoke-virtual {v1}, Landroid/view/View;->getWidth()I

    move-result v1

    neg-int v1, v1

    int-to-float v1, v1

    invoke-virtual {v0, v1}, Landroid/view/View;->setX(F)V

    :cond_2
    return-void
.end method
