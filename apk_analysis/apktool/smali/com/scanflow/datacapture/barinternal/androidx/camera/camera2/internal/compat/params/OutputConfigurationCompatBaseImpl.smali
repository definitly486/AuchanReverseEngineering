.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;
.super Ljava/lang/Object;
.source "OutputConfigurationCompatBaseImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat$OutputConfigurationCompatImpl;


# instance fields
.field final mObject:Ljava/lang/Object;


# direct methods
.method constructor <init>(Ljava/lang/Object;)V
    .locals 0

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 55
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;->mObject:Ljava/lang/Object;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    .line 215
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 219
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;->mObject:Ljava/lang/Object;

    check-cast p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;

    iget-object p1, p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;->mObject:Ljava/lang/Object;

    invoke-static {v0, p1}, Ljava/util/Objects;->equals(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public hashCode()I
    .locals 1

    .line 227
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompatBaseImpl;->mObject:Ljava/lang/Object;

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    return v0
.end method

.method public setMirrorMode(I)V
    .locals 0

    .line 87
    return-void
.end method

.method public setStreamUseCase(J)V
    .locals 0

    .line 100
    return-void
.end method
