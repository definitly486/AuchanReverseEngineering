.class public Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;
.super Landroid/widget/BaseAdapter;
.source "StreamsListViewAdapter.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Landroid/widget/BaseAdapter;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Auchan.Android.Streams.StreamsListViewAdapter, Auchan.Android.Net"

    const-string v2, ""

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_getCount()I
.end method

.method private native n_getItem(I)Ljava/lang/Object;
.end method

.method private native n_getItemId(I)J
.end method

.method private native n_getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;
.end method


# virtual methods
.method public getCount()I
    .locals 1

    .line 27
    invoke-direct {p0}, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->n_getCount()I

    move-result v0

    return v0
.end method

.method public getItem(I)Ljava/lang/Object;
    .locals 0

    .line 20
    invoke-direct {p0, p1}, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->n_getItem(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public getItemId(I)J
    .locals 2

    .line 34
    invoke-direct {p0, p1}, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->n_getItemId(I)J

    move-result-wide v0

    return-wide v0
.end method

.method public getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;
    .locals 0

    .line 41
    invoke-direct {p0, p1, p2, p3}, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->n_getView(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;

    move-result-object p1

    return-object p1
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 49
    iget-object v0, p0, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 50
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->refList:Ljava/util/ArrayList;

    .line 51
    :cond_0
    iget-object v0, p0, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 56
    iget-object v0, p0, Lcrc646e7dac6304ae8ce3/StreamsListViewAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 57
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method
