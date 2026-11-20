.class public Lmono/android/runtime/OutputStreamAdapter;
.super Ljava/io/OutputStream;
.source "OutputStreamAdapter.java"

# interfaces
.implements Lmono/android/IGCUserPeer;


# instance fields
.field private refList:Ljava/util/ArrayList;


# direct methods
.method public constructor <init>()V
    .locals 3

    .line 12
    invoke-direct {p0}, Ljava/io/OutputStream;-><init>()V

    .line 13
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    const-class v1, Lmono/android/runtime/OutputStreamAdapter;

    if-ne v0, v1, :cond_0

    const/4 v0, 0x0

    .line 14
    new-array v0, v0, [Ljava/lang/Object;

    const-string v1, "Android.Runtime.OutputStreamAdapter, Mono.Android"

    const-string v2, "System.IO.Stream, System.Private.CoreLib"

    invoke-static {v1, v2, p0, v0}, Lmono/android/TypeManager;->Activate(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;[Ljava/lang/Object;)V

    :cond_0
    return-void
.end method

.method private native n_close()V
.end method

.method private native n_flush()V
.end method

.method private native n_write(I)V
.end method

.method private native n_write([B)V
.end method

.method private native n_write([BII)V
.end method


# virtual methods
.method public close()V
    .locals 0

    .line 20
    invoke-direct {p0}, Lmono/android/runtime/OutputStreamAdapter;->n_close()V

    return-void
.end method

.method public flush()V
    .locals 0

    .line 27
    invoke-direct {p0}, Lmono/android/runtime/OutputStreamAdapter;->n_flush()V

    return-void
.end method

.method public monodroidAddReference(Ljava/lang/Object;)V
    .locals 1

    .line 56
    iget-object v0, p0, Lmono/android/runtime/OutputStreamAdapter;->refList:Ljava/util/ArrayList;

    if-nez v0, :cond_0

    .line 57
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lmono/android/runtime/OutputStreamAdapter;->refList:Ljava/util/ArrayList;

    .line 58
    :cond_0
    iget-object v0, p0, Lmono/android/runtime/OutputStreamAdapter;->refList:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public monodroidClearReferences()V
    .locals 1

    .line 63
    iget-object v0, p0, Lmono/android/runtime/OutputStreamAdapter;->refList:Ljava/util/ArrayList;

    if-eqz v0, :cond_0

    .line 64
    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    :cond_0
    return-void
.end method

.method public write(I)V
    .locals 0

    .line 48
    invoke-direct {p0, p1}, Lmono/android/runtime/OutputStreamAdapter;->n_write(I)V

    return-void
.end method

.method public write([B)V
    .locals 0

    .line 34
    invoke-direct {p0, p1}, Lmono/android/runtime/OutputStreamAdapter;->n_write([B)V

    return-void
.end method

.method public write([BII)V
    .locals 0

    .line 41
    invoke-direct {p0, p1, p2, p3}, Lmono/android/runtime/OutputStreamAdapter;->n_write([BII)V

    return-void
.end method
