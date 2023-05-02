package toolkitAndUtilities;

public class ErrorOrCancel extends RuntimeException {

	public ErrorOrCancel() {
		super();
	}

	public ErrorOrCancel(Throwable e) {
		super(e);
	}
}
