.class public Lmono/android/runtime/InputStreamAdapter;
.super Ljava/io/InputStream;
.source "InputStreamAdapter.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 4
    invoke-direct {p0}, Ljava/io/InputStream;-><init>()V

    return-void
.end method

.method private native n_close()V
.end method

.method private native n_read()I
.end method

.method private native n_read([B)I
.end method

.method private native n_read([BII)I
.end method


# virtual methods
.method public close()V
    .locals 0

    .line 12
    invoke-direct {p0}, Lmono/android/runtime/InputStreamAdapter;->n_close()V

    return-void
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 41
    iget-object v0, p0, Lmono/android/runtime/InputStreamAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 42
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lmono/android/runtime/InputStreamAdapter;->refList:Ljava/util/ArrayList;

    .line 43
    :cond_0
    iget-object v0, p0, Lmono/android/runtime/InputStreamAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 48
    iget-object v0, p0, Lmono/android/runtime/InputStreamAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 49
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public read()I
    .locals 1

    .line 19
    invoke-direct {p0}, Lmono/android/runtime/InputStreamAdapter;->n_read()I

    move-result v0

    return v0
.end method

.method public read([B)I
    .locals 0

    .line 26
    invoke-direct {p0, p1}, Lmono/android/runtime/InputStreamAdapter;->n_read([B)I

    move-result p1

    return p1
.end method

.method public read([BII)I
    .locals 0

    .line 33
    invoke-direct {p0, p1, p2, p3}, Lmono/android/runtime/InputStreamAdapter;->n_read([BII)I

    move-result p1

    return p1
.end method
