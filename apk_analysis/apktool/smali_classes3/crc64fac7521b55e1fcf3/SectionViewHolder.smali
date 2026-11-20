.class public Lcrc64fac7521b55e1fcf3/SectionViewHolder;
.super Landroidx/recyclerview/widget/RecyclerView$ViewHolder;
.source "SectionViewHolder.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# static fields
.field public static final __md_methods:Ljava/lang/String; = ""


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .line 14
    const-string v0, "Auchan.Android.Controls.SectionViewHolder, Auchan.Android.Net"

    const-class v1, Lcrc64fac7521b55e1fcf3/SectionViewHolder;

    const-string v2, ""

    invoke-static {v0, v1, v2}, Lmono/android/Runtime;->register(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/String;)V

    return-void
.end method

.method public constructor <init>(Landroid/view/View;)V
    .locals 2

    .line 19
    invoke-direct {p0, p1}, Landroidx/recyclerview/widget/RecyclerView$ViewHolder;-><init>(Landroid/view/View;)V

    .line 20
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lcrc64fac7521b55e1fcf3/SectionViewHolder;

    if-ne v0, v1, :cond_0

    .line 21
    const-string v0, "Android.Views.View, Mono.Android"

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    const-string v1, "Auchan.Android.Controls.SectionViewHolder, Auchan.Android.Net"

    invoke-static {v1, v0, p0, p1}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 28
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionViewHolder;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 29
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionViewHolder;->refList:Ljava/util/ArrayList;

    .line 30
    :cond_0
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionViewHolder;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 35
    iget-object v0, p0, Lcrc64fac7521b55e1fcf3/SectionViewHolder;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 36
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method
