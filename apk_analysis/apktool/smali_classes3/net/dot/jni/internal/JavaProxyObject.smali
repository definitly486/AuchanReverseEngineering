.class final Lnet/dot/jni/internal/JavaProxyObject;
.super Ljava/lang/Object;
.source "JavaProxyObject.java"

# interfaces
.implements Lnet/dot/jni/GCUserPeerable;


# instance fields
.field managedReferences:Ljava/util/ArrayList;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/ArrayList<",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 12
    const-class v0, Lnet/dot/jni/internal/JavaProxyObject;

    const-string v1, ""

    invoke-static {v0, v1}, Lnet/dot/jni/ManagedPeer;->registerNativeMembers(Ljava/lang/Class;Ljava/lang/String;)V

    return-void
.end method

.method constructor <init>()V
    .locals 1

    .line 7
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 17
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lnet/dot/jni/internal/JavaProxyObject;->managedReferences:Ljava/util/ArrayList;

    return-void
.end method


# virtual methods
.method public native equals(Ljava/lang/Object;)Z
.end method

.method public native hashCode()I
.end method

.method public jiAddManagedReference(Ljava/lang/Object;)V
    .locals 1

    .line 30
    iget-object v0, p0, Lnet/dot/jni/internal/JavaProxyObject;->managedReferences:Ljava/util/ArrayList;

    invoke-virtual {v0, p1}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method public jiClearManagedReferences()V
    .locals 1

    .line 35
    iget-object v0, p0, Lnet/dot/jni/internal/JavaProxyObject;->managedReferences:Ljava/util/ArrayList;

    invoke-virtual {v0}, Ljava/util/ArrayList;->clear()V

    return-void
.end method

.method public native toString()Ljava/lang/String;
.end method
